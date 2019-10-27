import React from "react"

import LogoImg from "../../../images/logo.png"

import "../styles/Logo.css"

function Logo() {
  return (
    <div className="logo-wrapper">
      <img className="img-fluid header-logo" alt="" src={LogoImg} />
    </div>
  )
}

export default Logo