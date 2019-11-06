import React from "react"

import "../styles/LoginButton.css"

import Button from "@material-ui/core/Button"
import Col from "react-bootstrap/Col"

class LoginButton extends React.Component {

    render() {
        return (
            <div>
                <Col lg={{ span: 12 }}>
                    {/* <Route path="/main" render={() => (this.getSession() ? (<Main to="/main" />) : <Redirect to="/" />)} /> */}
                    <Button variant="contained" color="primary" className="login-button mt-3" onClick={this.props.handleSubmit}>
                        Log In
                    </Button>
                </Col>
            </div>
        )
    }

}

export default LoginButton