import React from "react"

import PhotoImg from "../../../images/face.png"
import "../styles/Photo.css"

class Photo extends React.Component {

    render() {
        if (this.props.userPhoto !== undefined) {
            var photo = URL.createObjectURL(this.props.userPhoto)
            return (
                <div className="settings-photo-wrapper">
                    <img className="img-fluid settings-photo" alt="" src={photo} />
                </div>
            )
        }
        else if (this.props.recievedPhoto !== undefined) {
            var image = new Image()
            image.src = this.props.recievedPhoto
            return (
                <div className="settings-photo-wrapper">
                    <img className="img-fluid settings-photo" id="user-photo-123" alt="" src={image.src} />
                </div>
            )
        }
        else {
            return (
                <div className="settings-photo-wrapper">
                    <img className="img-fluid settings-photo" alt="" src={PhotoImg} />
                </div>
            )
        }

    }
}

export default Photo