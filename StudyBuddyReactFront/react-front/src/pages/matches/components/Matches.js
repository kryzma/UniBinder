import React from "react"

import Header from "../../header/components/Header"
import People from "../components/People"
import { USER_MATCHES } from "../../../config"

import { read_cookie } from 'sfcookies';

class Matches extends React.Component {

    constructor() {
        super()

        this.state = {
            Id: undefined,
            userList: [],
            listLength: undefined,
            loaded: false,
        }

        this.componentDidMount = this.componentDidMount.bind(this)
    }

    async componentDidMount() {

        var jwt = require("jsonwebtoken");
        var token = read_cookie("UserToken")

        try {
            if (token) {
                var decoded = jwt.decode(token)
                await this.setState({
                    Id: decoded.nameid
                })

            }
        } catch (error) {
            console.log(error)
        }

        fetch(USER_MATCHES + this.state.Id)
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
            .then(() => {
                this.setState({
                    loaded: true
                })
            })

    }

    render() {
        return (
            <div>
                <Header />
                <People listLength={this.state.listLength} userList={this.state.userList} loaded={this.state.loaded} />
            </div>
        )
    }
}

export default Matches