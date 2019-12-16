import React from 'react'
import Chatkit from '@pusher/chatkit-client'
import { INSTANCE_LOCATOR, ROOM_ID, USER_AUTHENTICATION_LINK, USER_FETCH_LINK } from "../../../config"
import MessageList from './MessageList'
import SendMessageForm from './SendMessageForm'
import TypingIndicator from './TypingIndicator'
import WhosOnlineList from './WhosOnlineList'
import Drawer from "@material-ui/core/Drawer"
import MenuIcon from '@material-ui/icons/Menu';

import { read_cookie } from 'sfcookies';

import "../styles/ChatScreen.css"

class ChatScreen extends React.Component {

    constructor(props) {
        super(props)
        this.state = {
            currentUser: {},
            currentRoom: {},
            messages: [],
            usersWhoAreTyping: [],
            currentLocalIp: 0,
            currentLink: 0,
            currentUsername: undefined,
            drawer: false,
        }
        this.sendMessage = this.sendMessage.bind(this)
        this.sendTypingEvent = this.sendTypingEvent.bind(this)
        this.componentDidMount = this.componentDidMount.bind(this)
        this.openDrawer = this.openDrawer.bind(this)
        this.closeDrawer = this.closeDrawer.bind(this)
    }

    // Send message function
    sendMessage(text) {
        this.state.currentUser.sendMessage({
            text,
            roomId: this.state.currentRoom.id,
        })
    }
    // Send typing event function
    sendTypingEvent() {
        this.state.currentUser
            .isTypingIn({ roomId: this.state.currentRoom.id })
            .catch(error => console.error('error', error))
    }


    async componentDidMount() {

        var jwt = require("jsonwebtoken");
        var token = read_cookie("UserToken")

        try {
            if (token) {
                var decoded = jwt.decode(token)
                await this.setState({
                    currentUsername: decoded.unique_name
                })

            }
        }
        catch (error) {
            console.log(error)
        }
        var username = {
            username: this.state.currentUsername
        }
        await fetch(USER_FETCH_LINK, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(username)
        })
            .then(response => {

                this.setState({
                    currentScreen: 'ChatScreen'
                })
            })
            .catch(error => console.log('error ', error, this.state.currentUsername))

            // Connect to instance with currentUser
            // Current instance is static atm, make instance manager in backend
            .then(() => {
                const chatManager = new Chatkit.ChatManager({
                    instanceLocator: INSTANCE_LOCATOR,
                    userId: this.state.currentUsername,
                    tokenProvider: new Chatkit.TokenProvider({
                        url: USER_AUTHENTICATION_LINK,
                    }),
                })
                return chatManager
            })
            .then(chatManager => {
                chatManager
                    .connect()
                    .then(currentUser => {
                        this.setState({ currentUser })
                        return currentUser.subscribeToRoom({
                            roomId: ROOM_ID,
                            messageLimit: 100,
                            hooks: {
                                onMessage: message => {
                                    this.setState({
                                        messages: [...this.state.messages, message],
                                    })
                                },
                                onUserStartedTyping: user => {
                                    this.setState({
                                        usersWhoAreTyping: [...this.state.usersWhoAreTyping, user.name],
                                    })
                                },
                                onUserStoppedTyping: user => {
                                    this.setState({
                                        usersWhoAreTyping: this.state.usersWhoAreTyping.filter(
                                            username => username !== user.name
                                        ),
                                    })
                                },
                                //Check who is online
                                onPresenceChange: () => this.forceUpdate(),
                            },
                        })
                    })
                    .then(currentRoom => {
                        this.setState({ currentRoom })
                    })
                    .catch(error => console.error('error', error))
            })


    }

    openDrawer() {
        this.setState({
            drawer: true
        })
    }
    closeDrawer() {
        this.setState({
            drawer: false
        })
    }

    render() {

        return (
            <div className="chat-container">
                <div className="online-header">
                    <MenuIcon className="online-hamburger" onClick={this.openDrawer} />
                </div>
                <div className="chat-window-container">
                    <Drawer className="online-drawer" anchor="left" open={this.state.drawer} onClose={this.closeDrawer}>
                        <WhosOnlineList
                            currentUser={this.state.currentUser}
                            users={this.state.currentRoom.users}
                        />
                    </Drawer>
                    <aside className="who-is-online-container">
                        <WhosOnlineList
                            currentUser={this.state.currentUser}
                            users={this.state.currentRoom.users}
                        />
                    </aside>
                    <section className="chat-list-container">
                        <MessageList
                            messages={this.state.messages}
                        //style={styles.chatList}
                        />
                        <TypingIndicator usersWhoAreTyping={this.state.usersWhoAreTyping} />
                        <SendMessageForm onSubmit={this.sendMessage} onChange={this.sendTypingEvent} />
                    </section>
                </div>
            </div>
        )
    }
}

export default ChatScreen