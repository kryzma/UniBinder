import React from "react"

import "../styles/ErrorMessage.css"

import Col from "react-bootstrap/Col"

class ErrorMessage extends React.Component {

    render() {
        if (!this.props.handleRepeat) {
            return (
                <Col lg={{ span: 12 }} className="error-message-col">
                    <div className="error-wrapper-settings mt-3">
                        Passwords doesn't match !
                    </div>
                </Col>
            )
        }
        else if (!this.props.handleName) {
            return (
                <Col lg={{ span: 12 }} className="error-message-col">
                    <div className="error-wrapper-settings mt-3">
                        Name can't be blank !
                    </div>
                </Col>
            )
        }
        else if (!this.props.handleSurname) {
            return (
                <Col lg={{ span: 12 }} className="error-message-col">
                    <div className="error-wrapper-settings mt-3">
                        Surname can't be blank !
                    </div>
                </Col>
            )
        }
        else if (!this.props.handleEmail) {
            return (
                <Col lg={{ span: 12 }} className="error-message-col">
                    <div className="error-wrapper-settings mt-3">
                        E-mail can't be blank !
                    </div>
                </Col>
            )
        }
        else if (!this.props.emailDublicate) {
            return (
                <Col lg={{ span: 12 }} className="error-message-col">
                    <div className="error-wrapper-settings mt-3">
                        E-mail already in use !
                    </div>
                </Col>
            )
        }
        else {
            return (
                <div>

                </div>
            )
        }
    }
}

export default ErrorMessage