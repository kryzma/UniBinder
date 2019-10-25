import React from "react"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"

function Username() {
  return (
    <Container>
      <Col lg={{ span: 10, offset: 1 }}>
        <h3>Username</h3>
        <input type="text"></input>
      </Col>
    </Container>

  )
}

export default Username