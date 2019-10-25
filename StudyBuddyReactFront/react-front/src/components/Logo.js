import React from "react"
import LogoPng from "../images/face.png"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"



function Logo() {
  return (
    <Container>
      <Col lg={{ span: 10, offset: 1 }}>
        <div className="logo-wrapper">
          <img className="img-fluid" alt="" src={LogoPng}></img>
        </div>
      </Col>
    </Container>
  )
}

export default Logo