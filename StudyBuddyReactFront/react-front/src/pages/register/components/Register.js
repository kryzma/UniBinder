import React from "react"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"

import Paper from "@material-ui/core/Paper"

import Logo from "./Logo"
import Name from "./Name"
import Username from "./Username"
import Email from "./Email"
import Password from "./Password"
import RegisterButton from "./RegisterButton"
import LoginButton from "./LoginButton"

import "../styles/Register.css"


function Register() {
    return (
        <div>
            <Container className="register-page">
                <Col lg={{ span: 4, offset: 4 }} md={{ span: 6, offset: 3 }} sm={{ span: 8, offset: 2 }} xs={{ span: 12, offset: 0 }}>
                    <Paper className="input-form-paper">
                        <Logo />
                        <Name />
                        <Username />
                        <Email />
                        <Password />
                        <RegisterButton />
                        <LoginButton />
                    </Paper>
                </Col>
            </Container>
        </div>
    )
}

export default Register