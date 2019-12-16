import React from 'react'

import { animateScroll } from "react-scroll";
import "../styles/MessageList.css"

class MessagesList extends React.Component {

    componentDidMount() {
        this.scrollToBottom()
    }
    componentDidUpdate() {
        this.scrollToBottom()
    }
    scrollToBottom() {
        animateScroll.scrollToBottom({
            containerId: "scrollContainer"
        });
    }

    render() {
        const styles = {
            container: {
                overflowY: 'scroll',
                flex: 1,
            }
        }
        return (
            <div className="message-list-wrapper" id="scrollContainer"
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