const express = require('express')
const bodyParser = require('body-parser')
const cors = require('cors')
const Chatkit = require('@pusher/chatkit-server')
const dotenv = require('dotenv');

const localIpUrl = require('local-ip-url');

dotenv.config();
const app = express()

const chatkit = new Chatkit.default({
    instanceLocator: `${process.env.INSTANCE_LOCATOR}`,
    key: `${process.env.KEY}`,
})

app.use(bodyParser.urlencoded({ extended: false }))
app.use(bodyParser.json())
app.use(cors())

// Get local ipv4
app.get('/api/ip', (req, res) => {
    res.setHeader('Content-Type', 'application/json');
    res.send(JSON.stringify({ ipv4: localIpUrl() }));
})

// Create chatkit user
// If user already exist send status 200
app.post('/users', (req, res) => {
    const { username } = req.body
    chatkit
        .createUser({
            id: username,
            name: username
        })
        .then(() => res.sendStatus(201))
        .catch(error => {
            if (error.error === 'services/chatkit/user_already_exists') {
                res.sendStatus(200)
            } else {
                res.status(error.status).json(error)
            }
        })
})

// Authenticate user, return user key
// Authenticates all atm, based on their username
app.post('/authenticate', (req, res) => {
    const authData = chatkit.authenticate({ userId: req.query.user_id })
    res.status(authData.status).send(authData.body)
})

const PORT = `${process.env.PORT_SERVER}`
app.listen(PORT, err => {
    if (err) {
        console.error(err)
    } else {
        console.log(`Running on port ${PORT}`)
    }
})

// Test server http://localhost:3001/api/greeting
app.get('/api/greeting', (req, res) => {
    const name = req.query.name || 'World';
    res.setHeader('Content-Type', 'application/json');
    res.send(JSON.stringify({ greeting: `Hello ${name}!` }));
});