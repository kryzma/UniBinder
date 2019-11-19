import React from 'react'

import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'

import UserChat from './UserChat'
import UserSettings from './UserSettings'
import UserSearch from './UserSearch'
import Header from '../../header/components/Header'

import { Link } from "react-router-dom"

import "../styles/Menu.css"


class Menu extends React.Component {
    render() {
        return (
            <div>
                <Header />
                <Container>
                    <Row>
                        <Col lg={{ span: 6 }}>
                            <Link className="user-search" to="/main">
                                <UserSearch />
                            </Link>
                        </Col>
                        <Col lg={{ span: 6 }}>
                            <Link className="user-chat" to="/chat">
                                <UserChat />
                            </Link>
                        </Col>
                    </Row>
                    <Row>
                        <Col lg={{ span: 6 }}>
                            <UserSettings />
                        </Col>
                    </Row>

                </Container>
            </div >
        )
    }
}

export default Menu