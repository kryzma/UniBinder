import React from "react"

import TextField from "@material-ui/core/TextField"
import "../styles/Surname.css"

class Surname extends React.Component {

    render() {
        return (
            <div className="settings-surname-input-wrapper">
                <TextField
                    label="Surname"
                    className="settings-surname-input"
                    margin="dense"
                    defaultValue={this.props.Surname}
                    key={this.props.Surname}
                    onChange={this.props.surnameChange}
                />
            </div>
        )
    }
}

export default Surname