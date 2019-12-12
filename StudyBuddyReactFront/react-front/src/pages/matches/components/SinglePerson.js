import React from "react"

import List from "@material-ui/core/List"
import ListItem from '@material-ui/core/ListItem';
import ListItemText from "@material-ui/core/ListItemText"
import Button from "@material-ui/core/Button"

import "../styles/SinglePerson.css"

class SinglePerson extends React.Component {

    render() {
        if (this.props.personList !== undefined) {
            this.list = this.props.personList.map((item, key) => {
                return (
                    <ListItem key={key} className="matched-person-list-item">
                        <ListItemText primary={item.Name + " " + item.Surname} />
                        <Button variant="contained" color="primary">
                            Unmatch
                        </Button>
                    </ListItem>
                )
            })

            return (
                <div>
                    <List>
                        {this.list}
                    </List>
                </div>
            )
        }
        else {
            return (
                <div>

                </div>
            )
        }
    }

}

export default SinglePerson