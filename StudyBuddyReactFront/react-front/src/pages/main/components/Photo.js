import React from "react"

import PhotoImg from "../../../images/face.png"

import "../styles/Photo.css"

function Photo() {
  return (
    <div className="photo-wrapper">
      <img className="img-fluid" alt="" src={PhotoImg} />
    </div>
  )
}

export default Photo