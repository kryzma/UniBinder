import React from "react"

import Container from "react-bootstrap/Container"
import Col from "react-bootstrap/Col"
import Paper from "@material-ui/core/Paper"
import Row from "react-bootstrap/Row"

import Photo from "./Photo.js"
import Header from "../../header/components/Header"
import Name from "../components/Name"
import Surname from "../components/Surname"
import Password from "../components/Password"
import ChangeButton from "../components/ChangeButton"
import Email from "../components/Email"
import Subjects from "../components/Subjects"
import SubjectChange from "../components/SubjectChange"
import ErrorMessage from "../components/ErrorMessage"
import PhotoSubmit from "../components/PhotoSubmit"
import PhotoUpload from "../components/PhotoUpload"

import { SUBJECT_LIST, USER_DATA, UPDATE_USER_DATA, UPLOAD_IMAGE, GET_IMAGE } from "../../../config"
import { read_cookie } from 'sfcookies';

import "../styles/Settings.css"

class Settings extends React.Component {

    constructor(props) {
        super(props)

        this.state = {
            subjects: [],
            name: undefined,
            changedName: undefined,
            surname: undefined,
            changedSurname: undefined,
            email: undefined,
            changedEmail: undefined,
            userSubjects: undefined,
            password: undefined,
            repeatPassword: undefined,
            passwordCorrect: true,
            nameCorrect: true,
            surnameCorrect: true,
            emailCorrect: true,
            hashedPassword: undefined,
            Id: undefined,
            emailDublicate: true,
            photo: undefined,
            photo64: undefined,
            recievedPhoto: undefined,
        }
        this.componentDidMount = this.componentDidMount.bind(this)
        this.handleSubjectChange = this.handleSubjectChange.bind(this)
        this.passwordChange = this.passwordChange.bind(this)
        this.repeatPasswordChange = this.repeatPasswordChange.bind(this)
        this.nameChange = this.nameChange.bind(this)
        this.emailChange = this.emailChange.bind(this)
        this.surnameChange = this.surnameChange.bind(this)
        this.handleChange = this.handleChange.bind(this)
        this.handleSubjectChangeOnSubmit = this.handleSubjectChangeOnSubmit.bind(this)
        this.handlePhotoSubmit = this.handlePhotoSubmit.bind(this)
        this.handlePhotoUpload = this.handlePhotoUpload.bind(this)
    }

    passwordChange(e) {
        this.setState({
            password: e.target.value
        })
    }
    repeatPasswordChange(e) {
        this.setState({
            repeatPassword: e.target.value
        })
    }

    nameChange(e) {
        this.setState({
            changedName: e.target.value
        })
    }

    surnameChange(e) {
        this.setState({
            changedSurname: e.target.value
        })
    }

    emailChange(e) {
        this.setState({
            changedEmail: e.target.value
        })
    }

    async handleChange() {
        // Check if passwords match
        // doesn't match
        if (this.state.password !== undefined && this.state.repeatPassword !== undefined && this.state.password !== this.state.repeatPassword) {
            this.setState({
                passwordCorrect: false
            })
        }
        // match
        if (this.state.password !== undefined && this.state.repeatPassword !== undefined && this.state.password === this.state.repeatPassword) {
            this.setState({
                passwordCorrect: true
            })
        }
        // handle if name is blank
        // blank
        if (this.state.changedName === "") {
            this.setState({
                nameCorrect: false
            })
        }
        // not blank
        if (this.state.changedName !== "") {
            this.setState({
                nameCorrect: true
            })
        }
        // handle if surname is blank
        // blank
        if (this.state.changedSurname === "") {
            this.setState({
                surnameCorrect: false
            })
        }
        // not blank
        if (this.state.changedSurname !== "") {
            this.setState({
                surnameCorrect: true
            })
        }
        // handle if email is blank
        // blank
        if (this.state.changedEmail === "") {
            this.setState({
                emailCorrect: false
            })
        }
        if (this.state.changedEmail !== "") {
            this.setState({
                emailCorrect: true
            })
        }
        if (this.state.emailCorrect && this.state.nameCorrect && this.state.passwordCorrect && this.state.surnameCorrect) {
            if (this.state.changedSurname === undefined) {
                await this.setState({
                    changedSurname: this.state.surname
                })
            }
            if (this.state.changedName === undefined) {
                await this.setState({
                    changedName: this.state.name
                })
            }
            if (this.state.changedEmail === undefined) {
                await this.setState({
                    changedEmail: this.state.email
                })
            }
            if (this.state.password === undefined) {

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

                fetch(UPDATE_USER_DATA, {
                    method: 'PATCH',
                    mode: "cors",
                    crossDomain: true,
                    body: JSON.stringify({
                        ID: this.state.Id,
                        Name: this.state.changedName,
                        Surname: this.state.changedSurname,
                        Email: this.state.changedEmail,
                    }),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                    .then(response => {
                        if (response.status === 400) {
                            this.setState({
                                emailDublicate: false
                            })
                        }
                        else {
                            this.setState({
                                emailDublicate: true
                            })
                        }
                    })
            }
            else {
                var passwordHash = require('password-hash')
                this.setState({
                    hashedPassword: passwordHash.generate(this.state.password)
                })

                jwt = require("jsonwebtoken");
                token = read_cookie("UserToken")

                try {
                    if (token) {
                        decoded = jwt.decode(token)
                        await this.setState({
                            Id: decoded.nameid
                        })

                    }
                } catch (error) {
                    console.log(error)
                }

                fetch(UPDATE_USER_DATA, {
                    method: 'PATCH',
                    mode: "cors",
                    body: JSON.stringify({
                        ID: this.state.Id,
                        Name: this.state.changedName,
                        Surname: this.state.changedSurname,
                        Email: this.state.changedEmail,
                        Password: this.state.hashedPassword,
                    }),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                })
                    .then(response => {
                        if (response.status === 400) {
                            this.setState({
                                emailDublicate: false
                            })
                        }
                        else {
                            this.setState({
                                emailDublicate: true
                            })
                        }
                    })
            }

        }
    }


    async componentDidMount() {
        fetch(SUBJECT_LIST)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    subjects: response
                })
            })

        var token = read_cookie("UserToken")

        fetch(USER_DATA + token)
            .then(response => response.json())
            .then(response => {
                this.setState({
                    name: response.Name,
                    surname: response.Surname,
                    email: response.Email,
                    userSubjects: response.Subjects
                })
            })

            .then(() => {
                this.userSubject = this.state.userSubjects.map(item => {
                    delete item["ID"]
                    return item
                })
                this.setState({
                    userSubjects: this.userSubject
                })
            })

        var jwt = require("jsonwebtoken");
        token = read_cookie("UserToken")

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

        await fetch(GET_IMAGE + this.state.Id)
            .then(response => { if (response.status !== 400) return response.json(); else return response })
            .then(response => {
                if (response.status !== 400) {
                    this.setState({
                        recievedPhoto: "data:image/jpeg;base64," + response
                    })
                }
            })


    }

    handleSubjectChange(selectedSubject) {

        // Check if item exists
        var exists = this.state.userSubjects.some(item => {
            return item.Name === selectedSubject
        })
        // Add if doesnt exist
        if (!exists) {
            this.setState(prevState => ({
                userSubjects: [...prevState.userSubjects, { Name: selectedSubject }]
            }))
        }
        // Delete if it already exists
        else {
            var objects2 = []
            var objects = this.state.userSubjects
            objects.forEach(item => {
                if (item.Name !== selectedSubject) {
                    objects2.push(item)
                }

            })
            this.setState(() => ({
                userSubjects: objects2
            }))
        }
    }

    async handleSubjectChangeOnSubmit() {


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

        fetch(UPDATE_USER_DATA, {
            method: 'PATCH',
            mode: "cors",
            body: JSON.stringify({
                ID: this.state.Id,
                Subjects: this.state.userSubjects
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        })
    }

    async handlePhotoSubmit() {
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
        await fetch(UPLOAD_IMAGE, {
            method: 'POST',
            body: JSON.stringify({
                ImgBase64: this.state.photo64,
                ImgPath: this.state.Id
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        })

    }

    async getBase64(file, cb) {
        let reader = new FileReader();
        reader.readAsDataURL(file);
        reader.onload = function () {
            cb(reader.result)
        };
        reader.onerror = function (error) {
            console.log('Error: ', error);
        };
    }

    async handlePhotoUpload(e) {
        await this.setState({
            photo: e.target.files[0]
        })

        if (this.state.photo !== undefined) {
            await this.getBase64(this.state.photo, async (result) => {
                await this.setState({
                    photo64: result
                })
            })
        }
    }



    render() {
        return (
            <div className="settings-wrapper">
                <Header />
                <Container className="settings-container">
                    <Row>
                        <Col lg={{ span: 6, offset: 0 }} xs={{ span: 12 }}>
                            <Paper className="settings-photo-paper">
                                <Container>
                                    <Photo userPhoto={this.state.photo} recievedPhoto={this.state.recievedPhoto} />
                                    <PhotoUpload handlePhotoUpload={this.handlePhotoUpload} />
                                    <PhotoSubmit handlePhotoSubmit={this.handlePhotoSubmit} />
                                </Container>
                            </Paper>
                        </Col>
                        <Col lg={{ span: 6, offset: 0 }} xs={{ span: 12 }}>
                            <Paper className="settings-main-paper">
                                <Name Name={this.state.name} nameChange={this.nameChange} />
                                <Surname Surname={this.state.surname} surnameChange={this.surnameChange} />
                                <Email Email={this.state.email} emailChange={this.emailChange} />
                                <Password passwordChange={this.passwordChange} repeatPasswordChange={this.repeatPasswordChange} />
                                <ErrorMessage handleRepeat={this.state.passwordCorrect} handleName={this.state.nameCorrect} handleSurname={this.state.surnameCorrect} handleEmail={this.state.emailCorrect} emailDublicate={this.state.emailDublicate} />
                                <ChangeButton handleChange={this.handleChange} />
                            </Paper>
                        </Col>
                    </Row>
                    <Col lg={{ span: 12 }} className="settings-subjects-col">
                        <Paper>
                            <Subjects handleSubjects={this.state.subjects} userSubjects={this.state.userSubjects} handleSubjectChange={this.handleSubjectChange} />
                        </Paper>
                        <SubjectChange handleSubjectChangeOnSubmit={this.handleSubjectChangeOnSubmit} />
                    </Col>
                </Container>
            </div>
        )
    }
}

export default Settings