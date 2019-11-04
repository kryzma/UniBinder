import React from "react"

import Button from "@material-ui/core/Button"

import "../styles/MatchButton.css"

function MatchButton() {
  return (
    <div className="match-button-wrapper">
      <Button variant="contained" color="primary" className="match-button">
        Match
    </Button>
    </div>
  )
}

export default MatchButton