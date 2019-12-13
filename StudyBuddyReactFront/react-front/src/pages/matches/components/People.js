import React from "react"

import Col from "react-bootstrap/Col"
import Container from "react-bootstrap/Container"

import "../styles/People.css"

import { read_cookie } from 'sfcookies';
import { PERSON_FETCH_LINK, REMOVE_MATCH } from "../../../config"
import SinglePerson from "./SinglePerson"
import ErrorMessage from "./ErrorMessage"

class People extends React.Component {

    constructor() {
        super()

        this.state = {
            name: undefined,
            surname: undefined,
            userList: [],
            isLoaded: true,
            Id: undefined,
            matchedId: undefined,
            unmatchSuccessful: undefined,
        }
        this.componentDidUpdate = this.componentDidUpdate.bind(this)
        this.handleUnmatch = this.handleUnmatch.bind(this)
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
                                surname: response.Surname,
                                matchedId: response.ID
                            })
                        })
                        .then(() => {
                            this.setState(prevState => ({
                                userList: [...prevState.userList, { Name: this.state.name, Surname: this.state.surname, ID: this.state.matchedId }]
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

    async handleUnmatch(personId) {
        var jwt = require("jsonwebtoken");
        var token = read_cookie("UserToken")

        try {
            if (token) {
                var decoded = jwt.decode(token)
                await this.setState({
                    Id: decoded.nameid
                })

            }
        }
        catch (error) {
            console.log(error)
        }
        await fetch(REMOVE_MATCH + this.state.Id + "&personID2=" + personId, {
            method: 'DELETE'
        })
            .then(response => {
                if (response.status === 200) {
                    this.setState({
                        unmatchSuccessful: true
                    })
                    setTimeout(() => {
                        this.setState({
                            unmatchSuccessful: undefined
                        })
                    }, 1000);
                }
            })
            .then(() => {
                var objects2 = []
                var objects = this.state.userList
                objects.forEach(item => {
                    if (item.ID !== personId) {
                        objects2.push(item)
                    }

                })
                this.setState(() => ({
                    userList: objects2,
                }))
            })
    }

    render() {
        if (this.props.listLength === 0 || this.props.listLength === undefined || this.state.userList.length === 0) {
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
                    <ErrorMessage unmatchSuccessful={this.state.unmatchSuccessful} />
                    <Container className="matched-person-list-container">
                        <SinglePerson personList={this.state.userList} handleUnmatch={this.handleUnmatch} />
                    </Container>
                </div>
            )
        }
    }
}

export default People