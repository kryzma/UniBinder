import React from "react"

import ChevronRightIcon from '@material-ui/icons/ChevronRight';

import "../styles/ArrowForward.css"

class ArrowForward extends React.Component {

  constructor(props) {
    super(props)

    this.handleClick = this.handleClick.bind(this)
  }

  handleClick = () => {
    this.props.changeId()
  }

  render() {
    // console.log(this.props.userCount + "props")
    // console.log(this.props.currentId + "ID")
    return (
      <div className="arrow-forward-wrapper">
        <ChevronRightIcon onClick={this.handleClick} className="arrow-forward" />
      </div>
    )
  }

}

export default ArrowForward