import React from "react"

import LogoImg from "../../../images/logo.png"
import { Link } from "react-router-dom"

import "../styles/Logo.css"

function Logo(props) {
  return (
    <Link to="/menu">
      <div className="logo-wrapper">
        <img className="img-fluid header-logo" alt="" src={LogoImg} onClick={props.handleClick} />
      </div>
    </Link>
  )
}

export default Logo