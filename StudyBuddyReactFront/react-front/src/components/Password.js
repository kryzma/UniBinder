import React from "react"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"

function Password() {
  return (

    <Container>
      <Col lg={{ span: 10, offset: 1 }}>
        <h3>Password</h3>
        <input type="password"></input>
      </Col>
    </Container>
  )
}

export default Password