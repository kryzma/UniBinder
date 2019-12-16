import React from "react"

import Container from "react-bootstrap/Container"
import ListItemText from "@material-ui/core/ListItemText"
import ListItem from "@material-ui/core/ListItem"
import List from "@material-ui/core/List"

import "../styles/Subjects.css"

class Subjects extends React.Component {
  render() {
    if (this.props.personSubjects !== undefined) {
      this.list = this.props.personSubjects.map((subject, key) => {
        return (
          <ListItem key={key} className="user-subject">
            <ListItemText primary={subject.Name} />
          </ListItem>
        )
      })
      return (
        <Container className="remove-padding">
          <List className="user-subjects-list">
            {this.list}
          </List>
        </Container>
      )
    }
    else {
      return (
        <div>
          Loading...
        </div>
      )
    }

  }
}


export default Subjects