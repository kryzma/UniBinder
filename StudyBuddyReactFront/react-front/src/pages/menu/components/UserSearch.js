import React from 'react'

import Container from 'react-bootstrap/Container'
import Row from 'react-bootstrap/Row'
import Col from 'react-bootstrap/Col'
import SearchIcon from '@material-ui/icons/Search';

import '../styles/UserSearch.css'

class UserSearch extends React.Component {


    render() {
        return (
            <div className="user-search-wrapper">
                <Container>
                    <Row>
                        <div className="user-search-row">
                            <Col lg={{ span: 4 }}>
                                <SearchIcon className="user-search-icon" />
                            </Col>
                            <Col className="user-search-title-col" lg={{ span: 8 }}>
                                <div className="user-search-title-wrapper">
                                    Search for new Buddies
                                </div>
                            </Col>
                        </div>
                    </Row>
                    <div className="user-search-description-wrapper">
                        Find new study buddies to learn with!
                    </div>
                </Container>
            </div>
        )
    }
}

export default UserSearch