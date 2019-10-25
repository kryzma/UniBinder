import React from "react"

import 'typeface-roboto';

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"

import Paper from "@material-ui/core/Paper"

import Logo from "./Logo"
import Username from "./Username"
import Password from "./Password"
import LoginButton from "./LoginButton"
import Register from "./RegisterButton"

import "../styles/Login.css"

function Login() {
  return (
    <Container className="auth-page">
      <Col lg={{ span: 4, offset: 4 }} md={{ span: 6, offset: 3 }} sm={{ span: 8, offset: 2 }} xs={{ span: 12, offset: 0 }}>
        <div className="app-wrapper">
          <Paper className="input-form-papper">
            <Logo />
            <Username />
            <Password />
            <LoginButton />
            <Register />
          </Paper>
        </div>
      </Col>
    </Container>
  )
}

export default Login