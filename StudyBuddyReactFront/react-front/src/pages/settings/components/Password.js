import React from "react"

import TextField from "@material-ui/core/TextField"
import "../styles/Password.css"

class Password extends React.Component {


    render() {
        return (
            <div>
                <div className="settings-password-input-wrapper">
                    <TextField
                        label="Change password"
                        className="settings-password-input"
                        margin="dense"
                        type="password"
                        onChange={this.props.passwordChange}
                    />
                </div>
                <div className="settings-repeat-password-input-wrapper">
                    <TextField
                        label="Repeat password"
                        className="settings-repeat-password-input"
                        margin="dense"
                        type="password"
                        onChange={this.props.repeatPasswordChange}
                    />
                </div>
            </div>
        )
    }
}

export default Password