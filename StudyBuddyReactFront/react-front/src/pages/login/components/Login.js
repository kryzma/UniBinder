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

import { GET_USER_PASSWORD } from "../../../config"

class Login extends React.Component {

  constructor() {
    super()

    this.state = ({
      username: undefined,
      password: undefined,
      hashedPassword: undefined,
      recievedPassword: undefined,
    })

    this.passwordChange = this.passwordChange.bind(this)
    this.usernameChange = this.usernameChange.bind(this)
    this.onSubmit = this.onSubmit.bind(this)
    this.checkPassword = this.checkPassword.bind(this)
  }

  passwordChange(e) {
    this.setState({
      password: e.target.value
    })
  }
  usernameChange(e) {
    this.setState({
      username: e.target.value
    })
  }

  onSubmit() {
    var passwordHash = require('password-hash')
    if (this.state.password !== undefined) {
      this.setState({
        hashedPassword: passwordHash.generate(this.state.password)
      }, () => {
        //this.checkPassword()
      })
    }
    this.checkPassword()
  }


  checkPassword() {
    var passwordHash = require('password-hash');

    fetch(GET_USER_PASSWORD + this.state.username)
      .then(response => response.json())
      .then(response => this.setState({
        recievedPassword: response
      }))
      .then(response => {
        if (passwordHash.verify(this.state.password, this.state.recievedPassword)) {
          // this.setState({
          //   password: undefined
          // })
          // do something if password is correct
          console.log(this.state.recievedPassword)
          console.log("true")
          console.log(this.state.hashedPassword)
        }
        else {
          console.log(this.state.recievedPassword)
          console.log(this.state.hashedPassword)
          // do something if false
        }
      })


  }


  render() {

    return (
      <div className="login-wrapper">
        <Container className="login-page">
          <Col lg={{ span: 4, offset: 4 }} md={{ span: 6, offset: 3 }} sm={{ span: 8, offset: 2 }} xs={{ span: 12, offset: 0 }}>
            <Paper className="input-form-paper">
              <Logo />
              <Username handleUsername={this.usernameChange} />
              <Password handlePassword={this.passwordChange} />
              <LoginButton handleSubmit={this.onSubmit} />
              <Register />
            </Paper>
          </Col>
        </Container>
      </div>
    )
  }

}

export default Login