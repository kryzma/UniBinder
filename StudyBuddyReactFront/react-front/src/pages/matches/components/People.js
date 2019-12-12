import React from "react"

import Col from "react-bootstrap/Col"
import Container from "react-bootstrap/Container"

import "../styles/People.css"

import { PERSON_FETCH_LINK } from "../../../config"
import SinglePerson from "./SinglePerson"

class People extends React.Component {

    constructor() {
        super()

        this.state = {
            name: undefined,
            surname: undefined,
            userList: [],
            isLoaded: true
        }
        this.componentDidUpdate = this.componentDidUpdate.bind(this)
    }

    async componentDidUpdate() {
        if (this.props.loaded && this.state.isLoaded) {
            if (this.props.listLength !== undefined) {
                this.props.userList.map(item => {
                    fetch(PERSON_FETCH_LINK + item)
                        .then(response => response.json())
                        .then(response => {
                            this.setState({
                                name: response.Name,
                                surname: response.Surname
                            })
                        })
                        .then(() => {
                            this.setState(prevState => ({
                                userList: [...prevState.userList, { Name: this.state.name, Surname: this.state.surname }]
                            }))
                        })
                    return item
                })

            }
            await this.setState({
                isLoaded: false
            })

        }
    }

    render() {
        if (this.props.listLength === 0 || this.props.listLength === undefined) {
            return (
                <Container className="matched-with-nothing-container">
                    <Col lg={{ span: 12 }}>
                        You are not matched with anyone,
                    </Col>
                    <Col lg={{ span: 12 }}>
                        Find some matches !
                    </Col>
                </Container>
            )
        }
        else {
            return (
                <div>
                    <Container className="matched-person-list-container">
                        <SinglePerson personList={this.state.userList} />
                    </Container>
                </div>
            )
        }
    }
}

export default People