import React from 'react'
import ChatIcon from '@material-ui/icons/Chat';
import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'

import '../styles/UserChat.css'

class UserChat extends React.Component {

    render() {
        return (
            <div className="user-chat-wrapper">
                <Container>
                    <Row>
                        <div className="user-chat-row">
                            <Col lg={{ span: 4 }}>
                                <ChatIcon className="user-chat-icon" />
                            </Col>
                            <Col className="user-chat-title-col" lg={{ span: 8 }}>
                                <div className="user-chat-title-wrapper">
                                    Chat with matched Buddies
                                </div>
                            </Col>
                        </div>
                    </Row>
                    <div className="user-chat-description-wrapper">
                        Exchange study plans and more!
                    </div>
                </Container>
            </div>
        )
    }
}

export default UserChat