import React from "react"

import PhotoImg from "../../../images/face.png"

import "../styles/Photo.css"

class Photo extends React.Component {

  render() {

    if (this.props.personImage !== undefined) {
      var image = new Image()
      image.src = this.props.personImage
      return (
        <div className="photo-wrapper">
          <img className="img-fluid user-photo-img" alt="" src={image.src} />
        </div>
      )
    }
    else {
      return (
        <div className="photo-wrapper">
          <img className="img-fluid user-photo-img" alt="" src={PhotoImg} />
        </div>
      )
    }
  }
}

export default Photo