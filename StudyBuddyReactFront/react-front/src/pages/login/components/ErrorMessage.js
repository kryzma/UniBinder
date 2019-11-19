import React from 'react'

import "../styles/ErrorMessage.css"
import Col from "react-bootstrap/Col"

class ErrorMessage extends React.Component {

    render() {
        if (this.props.passwordHandle === false) {
            return (
                <Col lg={{ span: 12 }} >
                    <div className="error-wrapper mt-3">
                        Password is incorrect !
                    </div>
                </Col>
            )
        }
        if (this.props.usernameHandle === false) {
            return (
                <Col lg={{ span: 12 }} >
                    <div className="error-wrapper mt-3">
                        User doesn't exist !
                    </div>
                </Col>
            )
        }
        else {
            return (
                <span></span>
            )
        }
    }
}

export default ErrorMessage