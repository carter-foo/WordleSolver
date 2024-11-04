import WordleLetter from "./WordleLetter";
import "./WordleGuess.css";
import { useState, useRef, useEffect } from "react";

function WordleGuess(props) {
  const letterRefs = useRef([]);

  useEffect(() => {
    letterRefs.current = letterRefs.current.slice(0, props.guess.letters.length)
  }, [props.guess.letters])

  const handleSetLetter = (newLetter, i) => {
    let newLetters = [...props.guess.letters]
    newLetters[i] = newLetter;
    props.setGuess({
      letters: newLetters,
      colors: props.guess.colors
    })
  }

  const handleSetColor = (newColor, i) => {
    let newColors = [...props.guess.colors];
    newColors[i] = newColor;
    props.setGuess({
      letters: props.guess.letters,
      colors: newColors
    });
  }

  const handleGoBack = (index) => {
    if (index > 0) {
      letterRefs.current[index - 1].focus();
    }
  }
  
  const handleGoForward = (index) => {
    if (index < props.guess.letters.length - 1) {
      letterRefs.current[index + 1].focus()
    }
  }

  const handleBackspace = (index) => {
    if (index > 0) {
      handleSetLetter("", index - 1);
      handleGoBack(index);
    }
  }

  const handleSubmit = (index) => {
    letterRefs.current[index].blur();
  }
  
  return (
    <div className="guess">
      {props.guess.letters.map((letter, i) => {
        return (
          <WordleLetter
            key={i}
            ref={x => letterRefs.current[i] = x}
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
    </div>
  );
}

export default WordleGuess;
