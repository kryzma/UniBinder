import React from "react"

import ChevronLeftIcon from '@material-ui/icons/ChevronLeft'

import "../styles/ArrowBack.css"

class ArrowBack extends React.Component {

  constructor(props) {
    super(props)

    this.handleClick = this.handleClick.bind(this)
  }

  handleClick = () => {
    this.props.changeId()
  }

  render() {
    return (
      <div className="arrow-back-wrapper">
        <ChevronLeftIcon onClick={this.handleClick} className="arrow-back" />
      </div>
    )
  }

}

export default ArrowBack