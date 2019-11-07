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
import ErrorMessage from "./ErrorMessage"

import { withRouter } from "react-router-dom"

import "../styles/Login.css"

import { GET_USER_PASSWORD, GET_USER_TOKEN } from "../../../config"
import { bake_cookie } from 'sfcookies';

class Login extends React.Component {

  constructor(props) {
    super(props)

    this.state = ({
      username: undefined,
      password: undefined,
      hashedPassword: undefined,
      recievedPassword: undefined,
      passwordCorrect: undefined,
      usernameCorrect: undefined,
    })

    this.passwordChange = this.passwordChange.bind(this)
    this.usernameChange = this.usernameChange.bind(this)
    this.onSubmit = this.onSubmit.bind(this)
    this.checkPassword = this.checkPassword.bind(this)
    this.redirect = this.redirect.bind(this)
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
    // Hash password
    // var passwordHash = require('password-hash')
    // if (this.state.password !== undefined) {
    //   this.setState({
    //     hashedPassword: passwordHash.generate(this.state.password)
    //   }, () => {
    //     //this.checkPassword()
    //   })
    // }
    this.checkPassword(this.redirect)
  }

  redirect() {
    if (this.state.usernameCorrect && this.state.passwordCorrect) {
      this.props.history.push("/menu")
    }
  }


  checkPassword(redirect) {
    var passwordHash = require('password-hash');

    fetch(GET_USER_PASSWORD + this.state.username)
      .then(response => {
        if (response.status === 404) {
          this.setState({
            usernameCorrect: false
          })
          throw new Error(response.status)
        }
        else {
          this.setState({
            usernameCorrect: true
          })
          return response
        }
      })
      .then(response => response.json())
      .then(response => this.setState({
        recievedPassword: response
      }))
      .then(() => {
        // do something if password is correct
        if (passwordHash.verify(this.state.password, this.state.recievedPassword)) {
          this.setState({
            // Pasalint passworda is state kai correct, nzn ar reikia
            // password: undefined,
            passwordCorrect: true
          })
          // GET user Token
          fetch(GET_USER_TOKEN + this.state.username)
            .then(response => response.json())
            .then(response => {
              bake_cookie("UserToken", response)
              console.log(response)
            })
            .then(() => redirect())
        }
        // do something if false
        else {
          this.setState({
            passwordCorrect: false
          })
        }
      })
      .catch(console.log)


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
              <ErrorMessage passwordHandle={this.state.passwordCorrect} usernameHandle={this.state.usernameCorrect} />
              <LoginButton handleSubmit={this.onSubmit} />
              <Register />
            </Paper>
          </Col>
        </Container>
      </div>
    )
  }

}

export default withRouter(Login)