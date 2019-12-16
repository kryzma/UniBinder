import React from "react"

import PersonOutlineIcon from '@material-ui/icons/PersonOutline';
import "../styles/Profile.css"

import { read_cookie } from 'sfcookies';
import { Link } from "react-router-dom"

class Profile extends React.Component {

  constructor(props) {
    super(props)

    this.state = {
      username: undefined,
    }

    this.componentDidMount = this.componentDidMount.bind(this)
  }

  componentDidMount() {
    var jwt = require("jsonwebtoken");
    var token = read_cookie("UserToken")

    try {
      if (token) {
        var decoded = jwt.decode(token)
        this.setState({
          username: decoded.unique_name
        })
      }
    }
    catch (error) {
      console.log(error)
    }
  }

  render() {
    return (

      <div className="profile-wrapper mr-3">
        <Link className="profile-name-link" to="/settings">
          <span className="pr-2">
            {this.state.username}
          </span>
          <PersonOutlineIcon className="profile-icon" />
        </Link>
      </div>

    )
  }
}

export default Profile