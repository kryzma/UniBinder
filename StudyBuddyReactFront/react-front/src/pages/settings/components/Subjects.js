import React from "react"
import List from "@material-ui/core/List"
import ListItem from '@material-ui/core/ListItem';
import ListItemText from "@material-ui/core/ListItemText"

import "../styles/Subjects.css"

class Subjects extends React.Component {

    render() {
        this.subject = this.props.handleSubjects.map((item, key) => {
            this.selected = false
            if (this.props.userSubjects !== undefined && this.props.userSubjects.length !== 0) {
                this.userSubject = this.props.userSubjects.map((item2 => {

                    if (item === item2.Name) {
                        this.selected = true
                    }
                    return item2
                }))
            }
            return (
                <ListItem key={key} className={this.selected ? "subject-selected settings-subject-list-item" : "settings-subject-list-item"}
                    onClick={() => { this.props.handleSubjectChange(item) }}>
                    <ListItemText
                        primary={item}
                    />
                </ListItem>
            )
        })
        return (
            <div className="settings-subject-list-wrapper">
                <List className="settings-subject-list">
                    {this.subject}
                </List>
            </div>
        )
    }
}

export default Subjects;