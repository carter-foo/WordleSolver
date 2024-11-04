import { useState } from "react";
import WordleGuess from "./components/WordleGuess";
import "./WordleSolver.css";

function WordleSolver() {
  const [guesses, setGuesses] = useState([
    { letters: ["", "", "", "", ""], colors: [1, 1, 1, 1, 1] },
  ]);

  const handleChangeGuess = (newGuess, i) => {
    let newGuesses = [...guesses];
    newGuesses[i] = newGuess;
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
              key={i}
            />
          );
        })}
      </div>
    </div>
  );
}

export default WordleSolver;
