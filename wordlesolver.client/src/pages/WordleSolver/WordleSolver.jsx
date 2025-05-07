import { useState } from "react";
import WordleGuess from "./../../components/WordleGuess/WordleGuess";
import NextGuesses from "./../../components/NextGuesses/NextGuesses";
import BackendConnector from "./../../network/BackendConnector";
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
  const [suggestions, setSuggestions] = useState([]);

  const handleChangeGuess = (newGuess, i) => {
    let newGuesses = [...guesses];
    newGuesses[i] = newGuess;
    setGuesses(newGuesses);
  };

  const handleAddGuess = (guessIndex) => {
    // Only add a new guess if the guess where the user hit enter is the last guess
    if (guessIndex === guesses.length - 1) {
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
  };

  const handleDeleteGuess = (index) => {
    let newGuesses = [...guesses];
    newGuesses.splice(index, 1);
    setGuesses(newGuesses);
  };

  const handleFindGuesses = () => {
    const connector = new BackendConnector();
    connector.getNextGuesses(guesses).then((suggestions) => {
      setSuggestions(suggestions);
    });
  }

  return (
    <div className="wordleSolver">
      <div className="mainContent">
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
      <div className="bottomBar">
        <div className="bottomBarContent">
          <button className="findGuessesButton" onClick={handleFindGuesses}>Find Guesses</button>
          <NextGuesses nextGuesses={suggestions}/>
        </div>
      </div>
    </div>
  );
}

export default WordleSolver;
