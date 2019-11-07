import React from "react"

import Col from "react-bootstrap/Col"
import TextField from "@material-ui/core/TextField"

function Username() {
  return (
    <div>
      <Col lg={{ span: 12 }}>
        <TextField
          label="Username"
          className="username-input"
          margin="dense"
        />
      </Col>
    </div>
  )
}

export default Username