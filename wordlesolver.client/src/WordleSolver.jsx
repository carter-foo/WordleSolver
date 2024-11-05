import { useState } from "react";
import WordleGuess from "./components/WordleGuess";
import "./WordleSolver.css";

function WordleSolver() {
  /*
  Color legend:
  1 - clear
  2 - yellow
  3 - green
  */

  const [guesses, setGuesses] = useState([
    { letters: ["", "", "", "", ""], colors: [1, 1, 1, 1, 1] },
  ]);

  const handleChangeGuess = (newGuess, i) => {
    let newGuesses = [...guesses];
    newGuesses[i] = newGuess;
    setGuesses(newGuesses);
  };

  const handleAddGuess = (guessIndex) => {
    // Only add a new guess if the guess where the user hit enter is the last guess
    if (guessIndex === guesses.length - 1) {
      console.log("Adding new guess");
      let newGuesses = [...guesses];
      newGuesses.push({
        letters: ["", "", "", "", ""],
        colors: [1, 1, 1, 1, 1],
      });
      setGuesses(newGuesses);
    }
  };

  const checkIfDeletable = () => {
    return guesses.length > 1;
  }

  const handleDeleteGuess = (index) => {
    let newGuesses = [...guesses];
    newGuesses.splice(index, 1);
    setGuesses(newGuesses);
  }

  return (
    <div>
      <div className="playfield">
        {guesses.map((guess, i) => {
          return (
            <WordleGuess
              guess={guess}
              setGuess={(newGuess) => handleChangeGuess(newGuess, i)}
              addGuess={() => handleAddGuess(i)}
              isDeletable={checkIfDeletable}
              deleteGuess={() => handleDeleteGuess(i)}
              key={i}
            />
          );
        })}
      </div>
    </div>
  );
}

export default WordleSolver;
