import React from "react"
import Login from "./pages/login/components/Login"
import Register from "./pages/register/components/Register"
import Main from "./pages/main/components/Main"
import chatMain from "./pages/chat/components/chatMain"
import { BrowserRouter as Router, Switch, Route } from "react-router-dom"

import 'typeface-roboto';

import "./styles/App.css"

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/" exact component={Login} />
        <Route path="/register" component={Register} />
        <Route path="/main" component={Main} />
        <Route path="/chat" component={chatMain} />
      </Switch>
    </Router>
  )
}

export default App