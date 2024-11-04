import React from "react";
import "./ColorPicker.css";

const ColorPicker = React.forwardRef((props, ref) => {
  const colorChange = (newColor) => {
    props.onColorChange(newColor);
    props.close();
  }
  return (
    <div className="colorPicker" ref={ref} tabIndex={0}>
      {/* tabIndex={0} enables color picker div to appear as a relatedTarget in letter's onBlur handler */}
      <button className="clearColorButton" onClick={() => {colorChange(1)}}></button>
      <button className="yellowColorButton" onClick={() => {colorChange(2)}}></button>
      <button className="greenColorButton" onClick={() => {colorChange(3)}}></button>
    </div>
  );
});

export default ColorPicker;
