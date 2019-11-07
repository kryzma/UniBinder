import React from "react"

import Container from "react-bootstrap/Container"
import Row from "react-bootstrap/Row"

import Logo from "./Logo"
import Logout from "./Logout"
import Profile from "./Profile"

import "../styles/Header.css"

class Header extends React.Component {

  render() {
    return (
      <header className="header-wrapper">
        <Container fluid={true}>
          <div className="left">
            <Logo />
          </div>
          <div className="right">
            <Row className="right-row">
              <Profile />
              <Logout />
            </Row>
          </div>
        </Container>
      </header>
    )
  }
}

export default Header