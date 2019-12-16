import React from "react"

import "../styles/PhotoUpload.css"

class PhotoUpload extends React.Component {

    render() {
        return (
            <div>
                <label htmlFor="photo-upload" className="photo-upload-label">
                    Upload Photo
                </label>
                <input id="photo-upload" type="file" accept="image/jpeg" onChange={this.props.handlePhotoUpload} />
            </div>
        )
    }
}

export default PhotoUpload