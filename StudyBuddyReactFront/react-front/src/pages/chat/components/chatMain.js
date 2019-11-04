import React from "react"
import { tokenUrl, userId, roomId, instanceLocator as instance } from "../../../config"
import ChatTest from "./chatTest"

import { ChatkitProvider, TokenProvider, withChatkit } from "@pusher/chatkit-client-react"

const tokenProvider = new TokenProvider({
  url: tokenUrl
})

const instanceLocator = instance

class ChatMain extends React.Component {

  constructor() {
    super()
    this.state = {
      message: []
    }
    this.componentDidMount = this.componentDidMount.bind(this)
    this.fetchMessages = this.fetchMessages.bind(this)
  }

  componentDidMount() {
    this.fetchMessages()
  }

  fetchMessages() {
    withChatkit(props => {
      props.chatkit.isLoading ? console.log("Loading") :
        props.chatkit.currentUser.fetchMultipartMessages({
          roomId: roomId,
          direction: 'older',
          limit: 10
        })
          .then(messages => {
            return messages.map(part => part.parts)
          })
          .then(items => {
            var messages = (items.map(item => { return item.map(item2 => { return ((item2.payload.content)) }) }))
            return messages
          })
          .then(messages => this.setState({
            message: messages
          }))
          .then(console.log(this.state.message))
          .catch(err => { console.log("Error fetching messages: " + err) })
    })
  }


  render() {
    return (
      <div>
        <ChatkitProvider
          instanceLocator={instanceLocator}
          tokenProvider={tokenProvider}
          userId={userId}>
          <ChatTest />
          {/* <WelcomeMessage /> */}
        </ChatkitProvider>
      </div>
    )
  }
}


// const WelcomeMessage = withChatkit(props => {
//   return (
//     <div>
//       {props.chatkit.isLoading
//         ? 'Connecting to Chatkit...'
//         : `Hello ${props.chatkit.currentUser.name}!`}

//     </div>
//   )
// })

// const RoomMessages = withChatkit(props => {
//   props.chatkit.isLoading ? console.log("Loading") :
//     props.chatkit.currentUser.fetchMultipartMessages({
//       roomId: roomId,
//       direction: 'older',
//       limit: 10
//     })
//       .then(messages => {
//         //console.log(messages.map((part, index) => part.parts))
//         return messages.map(part => part.parts)
//       })
//       .then(items => {
//         var messages = (items.map((item, index) => { return item.map(item2 => { return ((item2.payload.content)) }) }))
//         //var obj = (items.map(item => { return item }))
//         console.log(messages)
//         return messages
//       })
//       .catch(err => { console.log("Error fetching messages: " + err) })

//   // .then(messages.map(item => { console.log(item) })
//   //console.log(props.chatkit.currentUser)
//   // props.chatkit.currentUser.fetchMultipartMessages({
//   //   roomId: roomId,
//   //   direction: 'older',
//   //   limit: 10
//   // })
//   //   .then(messages => {
//   //     console.log(messages)
//   //   })
//   //   .catch(err => {
//   //     console.log('Error fetching messages: ' + err)
//   //   })
//   return (
//     <div></div>
//   )
// })

export default ChatMain