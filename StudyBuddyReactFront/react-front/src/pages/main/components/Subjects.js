import React from "react"

import Container from "react-bootstrap/Container"

import "../styles/Subjects.css"

class Subjects extends React.Component {
  render() {
    if (this.props.personSubjects !== undefined) {
      return (
        <Container>
          <ul className="subjects-ul">
            {this.props.personSubjects.map(subject => <li key={subject.Name}>{subject.Name}</li>)}
          </ul>
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