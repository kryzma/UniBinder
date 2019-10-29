import React from "react"

import Header from "../../header/components/Header"
import ArrowForward from "./ArrowForward"
import ArrowBack from "./ArrowBack"
import MainPaper from "./MainPaper"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"
import Row from "react-bootstrap/Row"

import "../styles/Main.css"

const API = "https://localhost:44363/api/Person/count"

class Main extends React.Component {

  constructor() {
    super()

    this.state = {
      currentId: 0,
      userCount: 0
    }
    this.componentDidMount = this.componentDidMount.bind(this)
    this.forwardId = this.forwardId.bind(this)
    this.backwardId = this.backwardId.bind(this)
  }

  componentDidMount() {
    fetch(API)
      .then(response => response.json())
      .then(response => this.setState({
        userCount: response - 1
      }))
      .catch(console.log)
  }

  forwardId() {
    console.log("Current id: " + this.state.currentId)
    console.log("Current userCount: " + this.state.userCount)
    if (this.state.currentId < this.state.userCount) {
      this.setState(prevState => {
        return {
          currentId: prevState.currentId + 1
        }
      })
    }
    else {
      this.setState(prevState => {
        let zero = 0
        return {
          currentId: zero
        }
      })
      console.log("else statement")
    }
  }

  backwardId() {
    console.log("Current id: " + this.state.currentId)
    console.log("Current userCount: " + this.state.userCount)
    if (this.state.currentId > 0) {
      this.setState(prevState => {
        return {
          currentId: prevState.currentId - 1
        }
      })
    }
    else {
      this.setState(prevState => {
        let max = this.state.userCount
        return {
          currentId: max
        }
      })
      console.log("else statement")
    }
  }



  render() {
    return (
      <div className="main-wrapper">
        <Header />
        <Container>
          <Col lg={{ span: 10, offset: 1 }}>
            <Row>
              <ArrowBack changeId={this.backwardId} />
              <MainPaper currentId={this.state.currentId} />
              <ArrowForward changeId={this.forwardId} />
            </Row>
          </Col>
        </Container>
      </div>
    )
  }

}

export default Main                                                    