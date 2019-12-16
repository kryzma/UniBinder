import React from "react"

import Button from "@material-ui/core/Button"

import "../styles/SubjectChange.css"

class SubjectChange extends React.Component {
    render() {
        return (
            <div className="subject-change-button-wrapper">
                <Button variant="contained" color="primary" className="subject-change-button" onClick={this.props.handleSubjectChangeOnSubmit}>
                    Save changes
                </Button>
            </div>
        )
    }
}

export default SubjectChange