import React from "react"

import Col from "react-bootstrap/Col"
import Row from "react-bootstrap/Row"
import TextField from "@material-ui/core/TextField"

import "../styles/Name.css"

function Name() {
  return (
    <div>
      <Row className="remove-margins">
        <Col lg={{ span: 6 }}>
          <TextField
            label="Name"
            className="username-input"
            margin="dense"
          />
        </Col>
        <Col lg={{ span: 6 }}>
          <TextField
            label="Surname"
            className="username-input"
            margin="dense"
          />
        </Col>
      </Row>
    </div>
  )
}

export default Name