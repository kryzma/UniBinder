import React from "react"

import TextField from "@material-ui/core/TextField"
import "../styles/Email.css"

class Email extends React.Component {

    render() {
        return (
            <div className="settings-email-input-wrapper">
                <TextField
                    label="E-mail"
                    className="settings-email-input"
                    margin="dense"
                    defaultValue={this.props.Email}
                    key={this.props.Email}
                    onChange={this.props.emailChange}
                />
            </div>
        )
    }
}

export default Email