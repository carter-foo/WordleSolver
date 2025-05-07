import "./NextGuesses.css";

function NextGuesses(props) {
  return (
    <div className="nextGuessesContainer">
      <div className="nextGuesses">
        {props.nextGuesses.map((guess, i) => {
          return (
            <div key={i} className="nextGuess">
              {guess}
            </div>
          );
        })}
      </div>
    </div>
  );
}

export default NextGuesses;
