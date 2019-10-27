import React from "react"

import ChevronLeftIcon from '@material-ui/icons/ChevronLeft'

import "../styles/ArrowBack.css"

function ArrowBack() {
  return (
    <div className="arrow-back-wrapper">
      <ChevronLeftIcon className="arrow-back" />
    </div>
  )
}

export default ArrowBack