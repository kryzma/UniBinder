import React from "react"
import ExitToAppOutlinedIcon from '@material-ui/icons/ExitToAppOutlined'
import { Link } from "react-router-dom"

import "../styles/Logout.css"

function Logout() {
  return (
    <div className="logout-wrapper">
      <Link to="/" className="logout-link">
        <span className="pr-2">
          Log out
      </span>
        <ExitToAppOutlinedIcon />
      </Link>
    </div>
  )
}

export default Logout