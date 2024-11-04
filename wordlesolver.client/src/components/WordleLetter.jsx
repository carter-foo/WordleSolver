import React, { useRef, useState } from "react";
import ColorPicker from "./ColorPicker";
import "./WordleLetter.css";

const WordleLetter = React.forwardRef((props, ref) => {
  const [showColorPicker, setShowColorPicker] = useState(false);
  const formRef = useRef(null);

  const handleKeyDown = (event) => {
    if (event.keyCode === 37) {
      // Left arrow
      props.goBack();
    } else if (event.keyCode === 39) {
      // Right arrow
      props.goForward();
    } else if (event.keyCode == 8) {
      // Backspace
      if (props.letter !== "") {
        props.setLetter("");
      } else {
        props.backspace();
      }
    } else if (event.keyCode >= 65 && event.keyCode <= 90) {
      // Between A and Z
      props.setLetter(String.fromCharCode(event.keyCode));
      props.goForward();
    } else if (event.keyCode == 13) {
      // Enter
      props.submit();
    }
  };

  const handleFocus = () => {
    setShowColorPicker(true);
  };

  const handleClick = () => {
    setShowColorPicker(true);
  };

  const handleBlur = (e) => {
    // Need to check if the user clicked on the color picker or one of its children so we don't lose focus
    if (formRef.current && formRef.current.contains(e.relatedTarget)) {
      // Retain focus on letter box and keep color picker open
      e.target.focus();
    } else {
      setShowColorPicker(false);
    }
  };

  const closeColorPicker = () => {
    setShowColorPicker(false);
  };

  const handleColorChange = (newColor) => {
    props.setColor(newColor);
  };

  const colorClass =
    props.color === 1
      ? "letterBox"
      : props.color === 2
      ? "letterBox yellow"
      : "letterBox green";

  return (
    <div>
      <div className={colorClass}>
        <input
          className="letterInput"
          type="text"
          value={props.letter}
          maxLength={1}
          ref={ref}
          readOnly={true}
          onKeyDown={handleKeyDown}
          onFocus={handleFocus}
          onClick={handleClick}
          onBlur={(e) => handleBlur(e)}
        />
        {showColorPicker ? (
          <ColorPicker
            ref={formRef}
            onColorChange={handleColorChange}
            close={closeColorPicker}
          />
        ) : null}
      </div>
    </div>
  );
});

export default WordleLetter;
