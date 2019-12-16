import React from "react"

import TextField from "@material-ui/core/TextField"
import "../styles/Name.css"

class Name extends React.Component {

    render() {
        return (
            <div className="settings-name-input-wrapper">
                <TextField
                    label="Name"
                    className="settings-name-input"
                    margin="dense"
                    key={this.props.Name}
                    defaultValue={this.props.Name}
                    onChange={this.props.nameChange}
                />
            </div>
        )
    }

}

export default Name