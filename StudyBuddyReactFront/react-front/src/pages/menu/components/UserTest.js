import React from 'react'

import Container from "react-bootstrap/Container"
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
// import SettingsIcon from '@material-ui/icons/Settings';

class UserTest extends React.Component {

  render() {
    return (
      <div className="user-settings-wrapper">
        <Container>
          <Row>
            <div className="user-settings-row">
              <Col lg={{ span: 4 }}>
                {/* <SettingsIcon cl assName="user-settings-icon" /> */}
              </Col>
              <Col lg={{ span: 8 }}>
                <div className="user-settings-title-wrapper">

                </div>
              </Col>
            </div>
          </Row>
          <div className="user-settings-description-wrapper">

          </div>
        </Container>
      </div>
    )
  }
}

export default UserTest
