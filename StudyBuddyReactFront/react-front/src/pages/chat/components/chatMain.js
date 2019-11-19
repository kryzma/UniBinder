import React from "react"
import UsernameForm from './UsernameForm'
import ChatScreen from "./ChatScreen"

import { IP_FETCH_LINK, SERVER_PORT } from "../../../config"

class ChatMain extends React.Component {

    constructor() {
        super()
        this.state = {
            currentUsername: '',
            currentScreen: 'WhatIsYourUsernameScreen',
            currentLocalIp: 0,
            currentLink: '',
        }
        this.onUsernameSubmitted = this.onUsernameSubmitted.bind(this)
    }
    // Create new user or change to existing one
    onUsernameSubmitted(username) {
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
                    currentLink: "http://" + this.state.currentLocalIp + ':' + SERVER_PORT + '/users'
                })
            })
            .then(response => {
                fetch(this.state.currentLink, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({ username })
                })
                    .then(response => {
                        this.setState({
                            currentUsername: username,
                            currentScreen: 'ChatScreen'
                        })
                    })
                    .catch(error => console.log('error ', error))
            })


    }

    render() {
        if (this.state.currentScreen === 'WhatIsYourUsernameScreen') {
            return <UsernameForm onSubmit={this.onUsernameSubmitted} />
        }
        if (this.state.currentScreen === 'ChatScreen') {
            return <ChatScreen currentUsername={this.state.currentUsername} />
        }

    }
}

export default ChatMain
