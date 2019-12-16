import React from "react"

import Container from "react-bootstrap/Container"
import Row from "react-bootstrap/Row"

import Logo from "./Logo"
import Logout from "./Logout"
import Profile from "./Profile"

import MenuIcon from '@material-ui/icons/Menu';
import "../styles/Header.css"
import { Drawer } from "@material-ui/core"

class Header extends React.Component {

  constructor(props) {
    super(props)

    this.state = {
      header: false
    }
    this.openDrawer = this.openDrawer.bind(this)
    this.closeDrawer = this.closeDrawer.bind(this)
  }

  closeDrawer() {
    this.setState({
      header: false
    })
  }
  openDrawer() {
    this.setState({
      header: true
    })
  }

  render() {
    return (
      <header className="header-wrapper">
        <Container fluid={true}>
          <div className="left">
            <Logo />
          </div>
          <Drawer className="header-drawer" anchor="top" open={this.state.header} onClose={this.closeDrawer}>
            <Logo />
            <Profile />
            <Logout />
          </Drawer>
          <div className="right">
            <Row className="right-row header-buttons">
              <Profile />
              <Logout />
            </Row>
            <MenuIcon className="header-hamburger" onClick={this.openDrawer} />
          </div>
        </Container>
      </header>
    )
  }
}

export default Header