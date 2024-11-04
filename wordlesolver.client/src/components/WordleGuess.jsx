import WordleLetter from "./WordleLetter";
import "./WordleGuess.css"
import { useRef } from "react";

function WordleGuess (props) {
  const ref1 = useRef(null);
  const ref2 = useRef(null);
  const ref3 = useRef(null);
  const ref4 = useRef(null);
  const ref5 = useRef(null);

  return (
    <div className="guess">
      <WordleLetter ref={ref1} nextRef={ref2}/>
      <WordleLetter ref={ref2} prevRef={ref1} nextRef={ref3}/>
      <WordleLetter ref={ref3} prevRef={ref2} nextRef={ref4}/>
      <WordleLetter ref={ref4} prevRef={ref3} nextRef={ref5}/>
      <WordleLetter ref={ref5} prevRef={ref4} onConfirm={() => {}}/>
    </div>
  )
}

export default WordleGuess;