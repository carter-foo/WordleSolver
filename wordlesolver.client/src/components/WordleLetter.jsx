import React, { useRef, useState } from "react";
import ColorPicker from "./ColorPicker";
import "./WordleLetter.css";

const WordleLetter = React.forwardRef((props, ref) => {
  const [letter, setLetter] = useState("");
  const [showColorPicker, setShowColorPicker] = useState(false);
  /*
  1 - clear
  2 - yellow
  3 - green
  */
  const [colorState, setColorState] = useState(1);

  const formRef = useRef(null);

  const goToPreviousLetter = () => {
    if (props.prevRef) {
      props.prevRef.current.focus();
    }
  };

  const goToNextLetter = () => {
    if (props.nextRef) {
      props.nextRef.current.focus();
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
      if (letter == "") {
        goToPreviousLetter();
      } else {
        setLetter("");
      }
    } else if (event.keyCode >= 65 && event.keyCode <= 90) {
      // Between A and Z
      setLetter(String.fromCharCode(event.keyCode));
      goToNextLetter();
    } else if (event.keyCode == 13) {
      // Enter
      props.onConfirm()
    }
  };

  const handleFocus = () => {
    setShowColorPicker(true);
  };

  const handleClick = () => {
    setShowColorPicker(true);
  }

  const handleBlur = (e) => {
    // Need to check if the user clicked on the color picker or one of its children so we don't lose focus
    if (formRef.current && formRef.current.contains(e.relatedTarget)) {
      // Retain focus on letter box and keep color picker open
      e.target.focus();
    } else {
      setShowColorPicker(false);
    }
  };

  const handleColorChange = (newColor) => {
    setColorState(newColor);
  }

  const closeColorPicker = () => {
    setShowColorPicker(false);
  }

  const colorClass =
    colorState === 1
      ? "letterBox"
      : colorState === 2
      ? "letterBox yellow"
      : "letterBox green";

  return (
    <div>
      <div className={colorClass}>
        <input
          className="letterInput"
          type="text"
          value={letter}
          maxLength={1}
          ref={ref}
          readOnly={true}
          onKeyDown={handleKeyDown}
          onFocus={handleFocus}
          onClick={handleClick}
          onBlur={e => handleBlur(e)}
        />
        {showColorPicker ? <ColorPicker ref={formRef} onColorChange={handleColorChange} close={closeColorPicker}/> : null}
      </div>
    </div>
  );
});

export default WordleLetter;
