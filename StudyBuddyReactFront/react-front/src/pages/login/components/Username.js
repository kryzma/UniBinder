import React from "react"

import Col from "react-bootstrap/Col"
import TextField from '@material-ui/core/TextField';

import "../styles/Username.css"

function Username() {
  return (
    <Col lg={{ span: 12 }}>
      <TextField
        label="Username"
        className="username-input"
        margin="dense"
      />
    </Col>
  )
}

export default Username