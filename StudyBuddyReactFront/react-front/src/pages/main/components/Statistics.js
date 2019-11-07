import React from "react"

import Container from "react-bootstrap/Container"

class Statistics extends React.Component {
  render() {
    return (
      <Container>
        <div>
          Likes
          <div>
            {this.props.personLikes}
          </div>
        </div>
      </Container>
    )
  }

}

export default Statistics