import React from "react"

import "../styles/LoginButton.css"

import { Link } from "react-router-dom"

import Button from "@material-ui/core/Button"
import Col from "react-bootstrap/Col"

class LoginButton extends React.Component {

    render() {
        return (
            <div>
                <Col lg={{ span: 12 }}>
                    {/* <Link to="/menu"> */}
                    <Button variant="contained" color="primary" className="login-button mt-3" onClick={this.props.handleSubmit}>
                        Log In
                    </Button>
                    {/* </Link> */}
                </Col>
            </div>
        )
    }

}

export default LoginButton