import React from "react"

import Col from "react-bootstrap/Col"
import Button from "@material-ui/core/Button"

import "../styles/RegisterButton.css"


function RegisterButton(props) {
  return (
    <div>
      <Col lg={{ span: 12 }}>
        <Button variant="contained" color="primary" className="register-button mt-3" onClick={props.handleSubmit}>
          Register
        </Button>
      </Col>
    </div>
  )
}

export default RegisterButton