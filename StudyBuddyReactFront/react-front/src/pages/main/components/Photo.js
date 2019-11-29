import React from "react"

import PhotoImg from "../../../images/face.png"

import "../styles/Photo.css"

class Photo extends React.Component {

  constructor(props) {
    super(props)

    this.state = {
      picture: undefined
    }
  }

  render() {
    return (
      <div className="photo-wrapper">
        <img className="img-fluid" alt="" src={PhotoImg} />
      </div>
    )
  }
}

export default Photo