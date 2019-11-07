import React from 'react'
import $ from 'jquery'

import "../styles/MessageList.css"

class MessagesList extends React.Component {

    componentDidMount() {
        // Scroll to the bottom of chat page in 5 ms
        var interval = setInterval(function () {
            $(".message-list-wrapper").scrollTop($(".message-list-wrapper").height());
            if ($(".message-list-wrapper").scrollTop() > 0) {
                clearInterval(interval)
            }
        }, 5);
    }

    render() {
        const styles = {
            container: {
                overflowY: 'scroll',
                flex: 1,
            }
        }
        return (
            <div className="message-list-wrapper"
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