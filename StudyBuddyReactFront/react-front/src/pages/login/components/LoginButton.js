import React from "react"

import "../styles/LoginButton.css"

import Button from "@material-ui/core/Button"
import Col from "react-bootstrap/Col"

function LoginButton() {
    return (
        <div>
            <Col lg={{ span: 12 }}>
                <Button variant="contained" color="primary" className="login-button mt-3">
                    Log In
                </Button>
            </Col>
        </div>
    )
}

export default LoginButton