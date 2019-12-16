import React from 'react'
import SettingsIcon from '@material-ui/icons/Settings';

import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'

import '../styles/UserSettings.css'

class UserSettings extends React.Component {
    render() {
        return (
            <div className="user-settings-wrapper">
                <Container>
                    <Row className="user-settings-row">
                        <Col className="user-settings-icon-col" lg={{ span: 4 }} md={{ span: 2 }} sm={{ span: 2 }} xs={{ span: 2 }}>
                            <SettingsIcon className="user-settings-icon" />
                        </Col>
                        <Col lg={{ span: 8 }} md={{ span: 10 }} sm={{ span: 10 }} xs={{ span: 10 }}>
                            <div className="user-settings-title-wrapper">
                                User Settings
                            </div>
                        </Col>
                    </Row>
                    <div className="user-settings-description-wrapper">
                        Change your current subjects, profile picture and more!
                    </div>
                </Container>
            </div>
        )
    }
}

export default UserSettings