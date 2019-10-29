import React from "react"

import PersonOutlineIcon from '@material-ui/icons/PersonOutline';
import "../styles/Profile.css"

function Profile() {
  return (
    <div className="profile-wrapper mr-3">
      <span className="pr-2">
        {'{'}Username{'}'}
      </span>
      <PersonOutlineIcon />
    </div>
  )
}

export default Profile