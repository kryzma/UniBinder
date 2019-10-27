import React from "react"

import Container from "react-bootstrap/Container"

import "../styles/Subjects.css"

function Subjects() {
  return (
    <Container>
      <ul className="subjects-ul">
        <li>
          Subject #1
        </li>
        <li>
          Subject #2
        </li>
        <li>
          Subject #3
        </li>
      </ul>
    </Container>
  )
}

export default Subjects