import React from "react"

import Col from "react-bootstrap/Col"
import TextField from "@material-ui/core/TextField"

function Password() {
  return (
    <div>
      <Col lg={{ span: 12 }}>
        <TextField
          label="Password"
          className="password-input"
          type="password"
          autoComplete="current-password"
          margin="dense"
        />
      </Col>
    </div>
  )
}

export default Password