import React from "react"
import Login from "./pages/login/components/Login"
import Register from "./pages/register/components/Register"
import { BrowserRouter as Router, Switch, Route } from "react-router-dom"

import 'typeface-roboto';

import "./styles/App.css"

function App() {
  return (
    <Router>
      <Switch>
        <Route path="/" exact component={Login} />
        <Route path="/register" component={Register} />
      </Switch>
    </Router>
  )
}

export default App