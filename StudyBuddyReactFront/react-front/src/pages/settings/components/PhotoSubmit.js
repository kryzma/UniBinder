import React from "react"

import Button from "@material-ui/core/Button"

import "../styles/PhotoSubmit.css"

class PhotoSubmit extends React.Component {

    render() {
        return (
            <div>
                <Button variant="contained" color="primary" className="save-photo-button" onClick={this.props.handlePhotoSubmit}>
                    Save changes
                </Button>
            </div>
        )
    }
}

export default PhotoSubmit