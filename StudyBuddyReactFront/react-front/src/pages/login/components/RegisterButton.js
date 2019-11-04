import React from "react"
import { Link } from "react-router-dom"

import Col from "react-bootstrap/Col"

function Register() {
    return (
        <Col lg={{ span: 12 }}>
            <div className="text-center mt-3">
                Don't have an account? <br />
                <Link to="/register">
                    Register here
                </Link>
            </div>
        </Col>
    )
}

export default Register