import React from "react"

import Header from "../../header/components/Header"
import Name from "./Name"
import Photo from "./Photo"
import Subjects from "./Subjects"
import Statistics from "./Statistics"
import MatchButton from "./MatchButton"
import ArrowForward from "./ArrowForward"
import ArrowBack from "./ArrowBack"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"
import Paper from "@material-ui/core/Paper"
import Row from "react-bootstrap/Row"

import "../styles/Main.css"

function Main() {
  return (
    <div className="main-wrapper">
      <Header />
      <Container>
        <Col lg={{ span: 10, offset: 1 }}>
          <Row>
            <ArrowBack />
            <Paper className="main-paper">
              <Name />
              <Row className="remove-margins">
                <Col lg={{ span: 4 }}>
                  <Statistics />
                </Col>
                <Col lg={{ span: 4 }}>
                  <Photo />
                </Col>
                <Col lg={{ span: 4 }}>
                  <Subjects />
                </Col>
              </Row>
              <MatchButton />
            </Paper>
            <ArrowForward />
          </Row>
        </Col>
      </Container>
    </div>
  )
}

export default Main                                                    