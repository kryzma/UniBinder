import React from "react"

import Button from "@material-ui/core/Button"

import "../styles/MatchButton.css"

function MatchButton(props) {
  return (
    <div className="match-button-wrapper">
      <Button variant="contained" color="primary" className="match-button" onClick={props.handleMatch}>
        Match
    </Button>
    </div>
  )
}

export default MatchButton