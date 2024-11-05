import WordleLetter from "./WordleLetter";
import "./WordleGuess.css";
import { useState, useRef, useEffect } from "react";
import binLogo from "../assets/bin.png";
import refreshLogo from "../assets/refresh.png";

function WordleGuess(props) {
  const [showSideButtons, setShowSideButtons] = useState(false);
  const letterRefs = useRef([]);

  useEffect(() => {
    letterRefs.current = letterRefs.current.slice(
      0,
      props.guess.letters.length
    );
    letterRefs.current[0].focus();
  }, []);

  const handleSetLetter = (newLetter, i) => {
    let newLetters = [...props.guess.letters];
    newLetters[i] = newLetter;
    props.setGuess({
      letters: newLetters,
      colors: props.guess.colors,
    });
  };

  const handleSetColor = (newColor, i) => {
    let newColors = [...props.guess.colors];
    newColors[i] = newColor;
    props.setGuess({
      letters: props.guess.letters,
      colors: newColors,
    });
  };

  const handleGoBack = (index) => {
    if (index > 0) {
      letterRefs.current[index - 1].focus();
    }
  };

  const handleGoForward = (index) => {
    if (index < props.guess.letters.length - 1) {
      letterRefs.current[index + 1].focus();
    }
  };

  const handleBackspace = (index) => {
    if (index > 0) {
      handleSetLetter("", index - 1);
      handleGoBack(index);
    }
  };

  const handleSubmit = (index) => {
    if (
      props.guess.letters.every((letter) => {
        return letter !== "";
      })
    ) {
      props.addGuess();
    }
    letterRefs.current[index].blur();
  };

  const handleMouseEnter = () => {
    setShowSideButtons(true);
  };

  const handleMouseLeave = () => {
    setShowSideButtons(false);
  };

  const handleDeleteRow = () => {
    props.deleteGuess();
  };

  const handleClearRow = () => {
    props.setGuess({ letters: ["", "", "", "", ""], colors: [1, 1, 1, 1, 1] });
  };

  return (
    <div
      className="guessRow"
      onMouseEnter={handleMouseEnter}
      onMouseLeave={handleMouseLeave}
    >
      <div className="guess">
        <div className="guessLetters">
          {props.guess.letters.map((letter, i) => {
            return (
              <WordleLetter
                key={i}
                ref={(x) => (letterRefs.current[i] = x)}
                letter={letter}
                color={props.guess.colors[i]}
                setLetter={(newLetter) => handleSetLetter(newLetter, i)}
                setColor={(newColor) => handleSetColor(newColor, i)}
                goBack={() => handleGoBack(i)}
                goForward={() => handleGoForward(i)}
                backspace={() => handleBackspace(i)}
                submit={() => handleSubmit(i)}
              />
            );
          })}
          {showSideButtons && (
            <div className="sideButtons">
              <button
                className="sideButton"
                title="Clear row"
                onClick={handleClearRow}
              >
                <img className="buttonLogo" src={refreshLogo} />
              </button>
              {props.isDeletable() && (
                <button
                  className="sideButton"
                  title="Delete row"
                  onClick={handleDeleteRow}
                >
                  <img className="buttonLogo" src={binLogo} />
                </button>
              )}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default WordleGuess;
