import React from "react"

import Container from "react-bootstrap/Container"

import "../styles/Subjects.css"

class Subjects extends React.Component {
  render() {
    // console.log(this.props.personSubjects.map(subject => subject.Name))
    return (
      <Container>
        <ul className="subjects-ul">
          {this.props.personSubjects.map(subject => <li key={subject.Name}>{subject.Name}</li>)}
        </ul>
      </Container>
    )
  }
}


export default Subjects