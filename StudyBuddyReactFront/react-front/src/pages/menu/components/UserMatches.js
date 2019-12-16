import React from 'react'
import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"
import Row from "react-bootstrap/Row"
import PeopleAltIcon from '@material-ui/icons/PeopleAlt';

class UserMatches extends React.Component {
    render() {
        return (
            <div className="user-chat-wrapper">
                <Container>
                    <Row className="user-chat-row">
                        <Col className="user-chat-icon-col" lg={{ span: 4 }} md={{ span: 2 }} sm={{ span: 2 }} xs={{ span: 2 }}>
                            <PeopleAltIcon className="user-chat-icon" />
                        </Col>
                        <Col className="user-chat-title-col" lg={{ span: 8 }} md={{ span: 10 }} sm={{ span: 10 }} xs={{ span: 10 }}>
                            <div className="user-chat-title-wrapper">
                                Check your matches
                            </div>
                        </Col>
                    </Row>
                    <div className="user-chat-description-wrapper">
                        Check your current matches and more!
                    </div>
                </Container>
            </div>
        )
    }
}

export default UserMatches