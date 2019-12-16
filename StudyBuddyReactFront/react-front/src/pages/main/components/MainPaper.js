import React from "react"

import Name from "./Name"
import Photo from "./Photo"
import Subjects from "./Subjects"
import MatchButton from "./MatchButton"

import Col from "react-bootstrap/Col"
import Paper from "@material-ui/core/Paper"
import Row from "react-bootstrap/Row"

import { PERSON_FETCH_LINK, GET_IMAGE, MATCH } from "../../../config"
import { read_cookie } from 'sfcookies';

class MainPaper extends React.Component {


    constructor(props) {
        super(props)

        this.state = {
            person: [],
            id: 0,
            name: "",
            likes: 0,
            email: "",
            subjects: [],
            surname: undefined,
            currentId: undefined,
            oldId: undefined,
            image: undefined,
            handleSuccess: undefined,
        }
        this.componentDidMount = this.componentDidMount.bind(this)
        this.componentDidUpdate = this.componentDidUpdate.bind(this)
        this.fetchItems = this.fetchItems.bind(this)
        this.handleMatch = this.handleMatch.bind(this)
    }

    componentDidMount() {
        this.fetchItems()
    }

    componentDidUpdate() {
        if (this.state.oldId !== this.props.currentId) {
            this.setState(prevState => {
                return {
                    oldId: this.props.currentId,
                    currentId: this.props.currentId
                }
            })
            this.fetchItems()
            this.setState({
                handleSuccess: undefined
            })
        }

    }

    fetchItems() {
        if (this.props.currentId !== undefined) {
            fetch(PERSON_FETCH_LINK + this.props.currentId)
                .then(response => response.json())
                .then((response) => {
                    // console.log(response)
                    return response
                })
                .then(responseJson => this.setState({
                    id: responseJson.ID,
                    likes: responseJson.Likes,
                    name: responseJson.Name,
                    surname: responseJson.Surname,
                    email: responseJson.Email,
                    subjects: responseJson.Subjects,
                    currentId: this.props.currentId,
                    oldId: this.props.currentId
                }))
                .catch(console.log)

            fetch(GET_IMAGE + this.props.currentId)
                .then(response => { if (response.status !== 400) return response.json(); else return response })
                .then(response => {
                    if (response.status !== 400) {
                        this.setState({
                            image: "data:image/jpeg;base64," + response
                        })
                    }
                    else {
                        this.setState({
                            image: undefined
                        })
                    }
                })
        }
    }

    handleMatch() {
        var token = read_cookie("UserToken")
        fetch(MATCH + token + "&victimID=" + this.props.currentId, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                if (response.status === 200) {
                    this.setState({
                        handleSuccess: true
                    })
                    this.props.handleMatch(this.props.currentId, true)
                }
            })

    }

    render() {
        return (

            <Paper className="main-paper">

                <Row className="remove-margins">
                    <Col xl={{ span: 9 }} lg={{ span: 12 }} className="profile-col">
                        <Name personName={this.state.name} personSurname={this.state.surname} />
                        <Photo personImage={this.state.image} />
                        <MatchButton handleMatch={this.handleMatch} />
                    </Col>
                    <Col xl={{ span: 3 }} lg={{ span: 12 }} className="remove-padding">
                        <Subjects personSubjects={this.state.subjects} />
                    </Col>
                </Row>
                <Col xl={{ span: 9 }}>

                </Col>
            </Paper>
        )
    }
}

export default MainPaper