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
                    <Row>
                        <div className="user-settings-row">
                            <Col lg={{ span: 4 }}>
                                <SettingsIcon className="user-settings-icon" />
                            </Col>
                            <Col lg={{ span: 8 }}>
                                <div className="user-settings-title-wrapper">
                                    User Settings
                                </div>
                            </Col>
                        </div>
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