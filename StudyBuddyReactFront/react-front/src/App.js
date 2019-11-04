import React from "react"
import Login from "./pages/login/components/Login"
import Register from "./pages/register/components/Register"
import Main from "./pages/main/components/Main"
import ChatMain from "./pages/chat/components/ChatMain"
import Menu from './pages/menu/components/Menu'
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
        <Route path="/chat" component={ChatMain} />
        <Route path="/menu" component={Menu} />
      </Switch>
    </Router>
  )
}

export default App