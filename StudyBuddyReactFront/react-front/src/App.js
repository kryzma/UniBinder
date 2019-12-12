import React from "react"
import Login from "./pages/login/components/Login"
import Register from "./pages/register/components/Register"
import Main from "./pages/main/components/Main"
import ChatMain from "./pages/chat/components/ChatMain"
import Menu from './pages/menu/components/Menu'
import Settings from "./pages/settings/components/Settings"
import Matches from "./pages/matches/components/Matches"
import { BrowserRouter as Router, Switch, Route, Redirect } from "react-router-dom"
import { read_cookie } from 'sfcookies'


import 'typeface-roboto';

import "./styles/App.css"

class App extends React.Component {

  constructor(props) {
    super(props)

    this.state = {
      redirect: false
    }
    this.getSession = this.getSession.bind(this)
  }

  getSession() {
    var jwt = require("jsonwebtoken");
    var token = read_cookie("UserToken")
    let session
    try {
      if (token) {
        var decoded = jwt.decode(token)
        session = decoded.exp
      }
    }
    catch (error) {
      console.log(error)
    }
    return session
  }


  render() {
    return (
      <Router>
        <Switch>
          <Route path="/" exact component={Login} />
          <Route path="/register" component={Register} />
          <Route path="/main" render={() => (this.getSession() ? (<Main to="/main" />) : <Redirect to="/" />)} />
          <Route path="/chat" render={() => (this.getSession() ? (<ChatMain to="/chat" />) : <Redirect to="/" />)} />
          <Route path="/menu" render={() => (this.getSession() ? (<Menu to="/menu" />) : <Redirect to="/" />)} />
          <Route path="/settings" render={() => (this.getSession() ? (<Settings to="/settings" />) : <Redirect to="/" />)} />
          <Route path="/matches" render={() => (this.getSession() ? (<Matches to="/matches" />) : <Redirect to="/" />)} />
          {/* <Route path="/menu" component={Menu} /> */}
        </Switch>
      </Router>
    )
  }

}

export default App