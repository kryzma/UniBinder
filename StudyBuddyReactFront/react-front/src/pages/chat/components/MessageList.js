import React from 'react'

import "../styles/MessageList.css"

class MessagesList extends React.Component {

    render() {
        const styles = {
            container: {
                overflowY: 'scroll',
                flex: 1,
            }
        }
        return (
            <div
                style={{
                    ...this.props.style,
                    ...styles.container,
                }}
            >
                <ul className="message-list-ul">
                    {this.props.messages.map((message, index) => (
                        <li key={index} className="message-list-li">
                            <div>
                                <span className="sender-username">{message.senderId}</span>{' '}
                            </div>
                            <p className="message">{message.text}</p>
                        </li>
                    ))}
                </ul>
            </div>
        )
    }
}

export default MessagesList