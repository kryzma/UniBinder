import React from "react"

import Button from "@material-ui/core/Button"
import "../styles/ChangeButton.css"

class ChangeButton extends React.Component {

    render() {
        return (
            <div className="change-button-wrapper">
                <Button variant="contained" color="primary" className="change-button" onClick={this.props.handleChange}>
                    Save changes
                </Button>
            </div>
        )
    }
}

export default ChangeButton