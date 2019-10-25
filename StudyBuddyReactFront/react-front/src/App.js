import React from "react"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"

import Logo from "./components/Logo"
import Username from "./components/Username"
import Password from "./components/Password"

import "./styles/App.css"

function App() {
  return (
    <Container>
      <Col lg={{ span: 4, offset: 4 }}>
        <div className="app-wrapper">
          <Logo />
          <Username />
          <Password />
        </div>
      </Col>
    </Container>
  )
}

export default App