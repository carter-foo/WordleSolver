import WordleGuess from "./components/WordleGuess";
import "./WordleSolver.css"

function WordleSolver () {

  return (
    <div>
      <div className="playfield">
        <WordleGuess />
        <WordleGuess />
        <WordleGuess />
        <WordleGuess />
        <WordleGuess />
        <WordleGuess />
      </div>
    </div>
  )
}

export default WordleSolver;