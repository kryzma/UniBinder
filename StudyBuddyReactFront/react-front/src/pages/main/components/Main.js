import React from "react"

import Header from "../../header/components/Header"
import ArrowForward from "./ArrowForward"
import ArrowBack from "./ArrowBack"
import MainPaper from "./MainPaper"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"
import Row from "react-bootstrap/Row"

import { read_cookie } from 'sfcookies';

import "../styles/Main.css"
import { LOAD_LIST } from "../../../config"


class Main extends React.Component {

  constructor() {
    super()

    this.state = {
      userList: [],
      currentId: 0,
      listLength: 0,
    }
    this.componentDidMount = this.componentDidMount.bind(this)
    this.forwardId = this.forwardId.bind(this)
    this.backwardId = this.backwardId.bind(this)
  }

  componentDidMount() {

    // fetch(PERSON_COUNT_LINK)
    //   .then(response => response.json())
    //   .then(response => this.setState({
    //     userCount: response - 1
    //   }))
    //   .catch(console.log)
    var token = read_cookie("UserToken")
    fetch(LOAD_LIST + token)
      .then(response => response.json())
      .then(response => {
        this.setState({
          userList: response
        })
      })
      .then(() => {
        this.setState({
          listLength: this.state.userList.length
        })
      })

  }

  forwardId() {
    if (this.state.currentId < this.state.listLength - 1) {
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
    }
  }

  backwardId() {
    if (this.state.currentId > 0) {
      this.setState(prevState => {
        return {
          currentId: prevState.currentId - 1
        }
      })
    }
    else {
      this.setState(prevState => {
        let max = this.state.listLength - 1
        return {
          currentId: max
        }
      })
    }
  }



  render() {
    if (this.state.listLength === 0) {
      return (
        <div>
          <Header />
          <Container className="matched-all-wrapper">
            <Col lg={{ span: 12 }}>
              You've matched with everyone !
          </Col>
            <Col lg={{ span: 12 }}>
              Select more subjects to find more matches !
          </Col>
          </Container>

        </div>
      )
    }
    else {
      return (
        <div className="main-wrapper">
          <Header />
          <Container>
            <Col lg={{ span: 10, offset: 1 }}>
              <Row>
                <ArrowBack changeId={this.backwardId} />
                <MainPaper currentId={this.state.userList[this.state.currentId]} />
                <ArrowForward changeId={this.forwardId} />
              </Row>
            </Col>
          </Container>
        </div>
      )
    }
  }

}

export default Main                                                    