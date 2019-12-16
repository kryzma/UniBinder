import React from "react"

import "../styles/Name.css"

import Col from "react-bootstrap/Col"

class Name extends React.Component {

  render() {
    return (
      <Col>
        <div className="name-wrapper">
          {this.props.personName} {this.props.personSurname}
        </div>
      </Col>
    )
  }

}

export default Name