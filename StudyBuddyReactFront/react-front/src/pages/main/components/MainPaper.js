import React from "react"

import Name from "./Name"
import Photo from "./Photo"
import Subjects from "./Subjects"
import Statistics from "./Statistics"
import MatchButton from "./MatchButton"

import Col from "react-bootstrap/Col"
import Paper from "@material-ui/core/Paper"
import Row from "react-bootstrap/Row"

const API = "https://localhost:44363/api/Person/"

class MainPaper extends React.Component {


    constructor() {
        super()

        this.state = {
            person: [],
            id: 0,
            name: "",
            likes: 0,
            email: "",
            subjects: [],
            currentId: 0,
            oldId: 0,
            image: 0
        }
        this.componentDidMount = this.componentDidMount.bind(this)
        this.componentDidUpdate = this.componentDidUpdate.bind(this)
        this.fetchItems = this.fetchItems.bind(this)
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
        fetch(API + this.props.currentId)
            .then(response => response.json())
            .then((response) => {
                console.log(response)
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
    }

    render() {
        return (

            <Paper className="main-paper">
                <Name personName={this.state.name} />
                <Row className="remove-margins">
                    <Col lg={{ span: 4 }}>
                        <Statistics personLikes={this.state.likes} />
                    </Col>
                    <Col lg={{ span: 4 }}>
                        <Photo />
                    </Col>
                    <Col lg={{ span: 4 }}>
                        <Subjects personSubjects={this.state.subjects} />
                    </Col>
                </Row>
                <MatchButton />
            </Paper>
        )
    }
}

export default MainPaper