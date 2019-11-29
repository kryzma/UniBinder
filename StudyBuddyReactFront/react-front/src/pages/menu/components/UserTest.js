import React from 'react'
import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"
import Row from "react-bootstrap/Row"

class UserTest extends React.Component {
    render() {
        return (
            <div className="user-search-wrapper">
                <Container>
                    <Row className="user-search-row">
                        <Col lg={{ span: 4 }} md={{ span: 2 }}>
                            {/* <SearchIcon className="user-search-icon" /> */}
                        </Col>
                        <Col className="user-search-title-col" lg={{ span: 8 }} md={{ span: 10 }}>
                            <div className="user-search-title-wrapper">
                            </div>
                        </Col>
                    </Row>
                    <div className="user-search-description-wrapper">
                    </div>
                </Container>
            </div>
        )
    }
}

export default UserTest