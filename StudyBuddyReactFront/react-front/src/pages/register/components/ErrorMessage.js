import React from 'react'

import "../styles/ErrorMessage.css"
import Col from "react-bootstrap/Col"

class ErrorMessage extends React.Component {


    render() {
        if (this.props.usernameHandle === false) {
            return (

                <Col lg={{ span: 12 }} >
                    <div className="error-wrapper mt-3">
                        Username is already in use !
                    </div>
                </Col>
            )
        }
        if (this.props.emailHandle === false) {
            return (
                <Col lg={{ span: 12 }} >
                    <div className="error-wrapper mt-3">
                        E-mail is already in use !
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