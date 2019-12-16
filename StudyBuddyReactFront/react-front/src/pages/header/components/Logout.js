import React from "react"
import ExitToAppOutlinedIcon from '@material-ui/icons/ExitToAppOutlined'
import { Link } from "react-router-dom"

import { delete_cookie } from 'sfcookies'

import "../styles/Logout.css"

class Logout extends React.Component {

  constructor(props) {
    super(props)

    this.handleLogout = this.handleLogout.bind(this)
  }

  handleLogout() {
    delete_cookie("UserToken")
  }

  render() {
    return (
      <div className="logout-wrapper">
        <Link to="/" className="logout-link" onClick={this.handleLogout}>
          <span className="pr-2">
            Log out
        </span>
          <ExitToAppOutlinedIcon className="logout-icon" />
        </Link>
      </div>
    )
  }

}

export default Logout