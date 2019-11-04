import React from "react"

import { withChatkit } from "@pusher/chatkit-client-react"

class ChatTest extends React.Component {

  constructor(props) {
    super(props)

    this.state = {
      name: ""
    }

    this.componentDidMount = this.componentDidMount.bind(this)
    this.fetchMessage = this.fetchMessage.bind(this)
  }

  componentDidMount() {
    this.fetchMessage()
  }

  fetchMessage() {
    withChatkit(props => {
      console.log(props)
      if (props.chatkit.isLoading) {
        this.setState({
          name: props.chatkit.currentUser.name
        })
      }
    })
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

  render() {
    return (
      <div>
        {this.state.name}
      </div>
    )
  }
}

export default ChatTest