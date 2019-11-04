import React from "react"

import Col from "react-bootstrap/Col"
import { Link } from "react-router-dom"

function LoginButton() {
  return (
    <Col lg={{ span: 12 }}>
      <div className="text-center mt-3">
        Already have an account? <br />
        <Link to="/">
          Log In here
        </Link>
      </div>
    </Col>
  )
}

export default LoginButton