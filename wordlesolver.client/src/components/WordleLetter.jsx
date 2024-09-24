import React, { useState } from "react";
import "./WordleLetter.css";

const WordleLetter = React.forwardRef((props, ref) => {
  const [letter, setLetter] = useState("");
  
  const goToPreviousLetter = () => {
    if (props.prevRef) {
      props.prevRef.current.focus();
    }
  }

  const goToNextLetter = () => {
    if (props.nextRef) {
      props.nextRef.current.focus();
    }
  }
  
  const handleInputChange = (event) => {
    console.log(event.target.value.length)
    if (event.target.value.length === 1) {
      goToNextLetter();
    }
  };

  const handleKeyDown = (event) => {
    if (event.keyCode === 37) {
      // Left arrow
      goToPreviousLetter();
    } else if (event.keyCode === 39) {
      // Right arrow
      goToNextLetter();
    } else if (event.keyCode == 8) {
      // Backspace
      setLetter("");
    } else if (event.keyCode >= 65 && event.keyCode <= 90) {
      // Between A and Z
      setLetter(String.fromCharCode(event.keyCode))
      goToNextLetter();
    }
  }

  return (
    <div>
      <div className="letterBox">
        <input
          className="letterInput"
          type="text"
          value={letter}
          maxLength={1}
          ref={ref}
          //onChange={handleInputChange}
          onKeyDown={handleKeyDown}
        ></input>
      </div>
    </div>
  );
});

export default WordleLetter;
