import React from "react"

import Col from "react-bootstrap/Col"
import "../styles/ErrorMessage.css"

class ErrorMessage extends React.Component {

    render() {
        return (
            <Col lg={{ span: 12 }} >
                <div className={this.props.unmatchSuccessful ? "unmatch-success-error-wrapper" : "hidden unmatch-success-error-wrapper"}>
                    Successfully unmatched !
                </div>
            </Col>
        )
    }
}

export default ErrorMessage