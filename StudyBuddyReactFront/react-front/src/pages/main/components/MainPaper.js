import React from "react"

import Name from "./Name"
import Photo from "./Photo"
import Subjects from "./Subjects"
import Statistics from "./Statistics"
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
            currentId: undefined,
            oldId: undefined,
            image: undefined
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
        console.log(this.props.currentId)
        fetch(MATCH + token + "&victimID=" + this.props.currentId, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            }
        })

    }

    render() {
        return (

            <Paper className="main-paper">
                <Name personName={this.state.name} />
                <Row className="remove-margins">
                    <Col lg={{ span: 3 }}>
                        <Statistics personLikes={this.state.likes} />
                    </Col>
                    <Col lg={{ span: 6 }}>
                        <Photo personImage={this.state.image} />
                    </Col>
                    <Col lg={{ span: 3 }}>
                        <Subjects personSubjects={this.state.subjects} />
                    </Col>
                </Row>
                <MatchButton handleMatch={this.handleMatch} />
            </Paper>
        )
    }
}

export default MainPaper