import React from "react"

import Col from "react-bootstrap/Col"
import Row from "react-bootstrap/Row"
import TextField from "@material-ui/core/TextField"

import "../styles/Name.css"

function Name(props) {
  return (
    <div>
      <Row className="remove-margins">
        <Col lg={{ span: 6 }}>
          <TextField
            label="Name"
            className="username-input"
            margin="dense"
            onChange={props.handleName}
          />
        </Col>
        <Col lg={{ span: 6 }}>
          <TextField
            label="Surname"
            className="username-input"
            margin="dense"
            onChange={props.handleSurname}
          />
        </Col>
      </Row>
    </div>
  )
}

export default Name