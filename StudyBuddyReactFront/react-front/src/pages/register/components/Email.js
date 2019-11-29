import React from "react"

import Col from "react-bootstrap/Col"
import TextField from "@material-ui/core/TextField"

function Email(props) {
  return (
    <div>
      <Col lg={{ span: 12 }}>
        <TextField
          label="E-Mail"
          className="username-input"
          margin="dense"
          onChange={props.handleEmail}
        />
      </Col>
    </div>
  )
}

export default Email