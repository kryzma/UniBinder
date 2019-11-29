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

import { bake_cookie } from 'sfcookies';
import { REGISTER_USER, GET_USER_TOKEN } from "../../../config"


class Register extends React.Component {

    constructor(props) {
        super(props)

        this.state = ({
            name: undefined,
            surname: undefined,
            username: undefined,
            email: undefined,
            password: undefined,
            hashedPassword: undefined,
            usernameCorrect: undefined,
            emailCorrect: undefined,
        })
        this.nameChange = this.nameChange.bind(this)
        this.surnameChange = this.surnameChange.bind(this)
        this.usernameChange = this.usernameChange.bind(this)
        this.emailChange = this.emailChange.bind(this)
        this.passwordChange = this.passwordChange.bind(this)
        this.onSubmit = this.onSubmit.bind(this)
        this.redirect = this.redirect.bind(this)
        this.handleRegister = this.handleRegister.bind(this)
    }

    nameChange(e) {
        this.setState({
            name: e.target.value
        })
    }
    surnameChange(e) {
        this.setState({
            surname: e.target.value
        })
    }
    usernameChange(e) {
        this.setState({
            username: e.target.value
        })
    }
    emailChange(e) {
        this.setState({
            email: e.target.value
        })
    }
    passwordChange(e) {
        this.setState({
            password: e.target.value
        })

    }

    redirect() {
        // Check if everything is OK
        if (true) {
            this.props.history.push("/menu")
        }
    }

    onSubmit() {
        var passwordHash = require('password-hash')
        if (this.state.password !== undefined) {
            this.setState({
                hashedPassword: passwordHash.generate(this.state.password)
            }, () => {
                this.handleRegister(this.redirect)
            })
        }
    }

    handleRegister(redirect) {

        fetch(REGISTER_USER, {
            method: 'post',
            body: JSON.stringify({
                Username: this.state.username,
                Password: this.state.hashedPassword,
                Name: this.state.name,
                Surname: this.state.surname,
                Email: this.state.email,
                Role: 'user',
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                if (response.status === 400) {
                    this.setState({
                        usernameCorrect: false
                    })
                    console.log("username incorrect")
                    //throw new Error(response.status)
                }
                if (response.status === 409) {
                    this.setState({
                        emailCorrect: false
                    })
                    console.log("email incorrect")
                    //throw new Error(response.status)
                }
                else {
                    this.setState({
                        usernameCorrect: true,
                        emailCorrect: true
                    })
                }
            })
            .then(
                fetch(GET_USER_TOKEN + this.state.username)
                    .then(response => response.json())
                    .then(response => {
                        bake_cookie("UserToken", response)
                    })
                //.then(() => redirect())
            )
    }


    render() {
        return (
            <div className="register-wrapper">
                <Container className="register-page">
                    <Col lg={{ span: 4, offset: 4 }} md={{ span: 6, offset: 3 }} sm={{ span: 8, offset: 2 }} xs={{ span: 12, offset: 0 }}>
                        <Paper className="input-form-paper">
                            <Logo />
                            <Name handleName={this.nameChange} handleSurname={this.surnameChange} />
                            <Username handleUsername={this.usernameChange} />
                            <Email handleEmail={this.emailChange} />
                            <Password handlePassword={this.passwordChange} />
                            <RegisterButton handleSubmit={this.onSubmit} />
                            <LoginButton />
                        </Paper>
                    </Col>
                </Container>
            </div>
        )
    }
}

export default Register