import React from 'react'
import Chatkit from '@pusher/chatkit-client'
import { INSTANCE_LOCATOR, ROOM_ID, IP_FETCH_LINK, SERVER_PORT } from "../../../config"
import MessageList from './MessageList'
import SendMessageForm from './SendMessageForm'
import TypingIndicator from './TypingIndicator'
import WhosOnlineList from './WhosOnlineList'

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
        }
        this.sendMessage = this.sendMessage.bind(this)
        this.sendTypingEvent = this.sendTypingEvent.bind(this)
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


    componentDidMount() {

        // Get local ipv4 adress
        fetch(IP_FETCH_LINK, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
        })
            .then(response => {
                response = response.json()
                return response
            })
            .then(response => {
                this.setState({
                    currentLocalIp: response.ipv4
                })

            })
            .then(response => {
                this.setState({
                    currentLink: "http://" + this.state.currentLocalIp + ':' + SERVER_PORT + '/authenticate'
                })
            })
            // Connect to instance with currentUser
            // Current instance is static atm, make instance manager in backend
            .then(response => {
                const chatManager = new Chatkit.ChatManager({
                    instanceLocator: INSTANCE_LOCATOR,
                    userId: this.props.currentUsername,
                    tokenProvider: new Chatkit.TokenProvider({
                        url: this.state.currentLink,
                    }),
                })
                return chatManager
            })
            .then(response => {
                response
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

    render() {

        return (
            <div className="chat-container">
                <div className="chat-window-container">
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