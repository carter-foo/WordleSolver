import AxiosClient from "./AxiosClient";

class BackendConnector {
  constructor() {
    this.axiosClient = new AxiosClient("https://localhost:7095");
  }
  
  async getNextGuesses(guessList) {
    const body = this.formatRequestBody(guessList);
    console.log("Request Body:", body);
    const data = await this.axiosClient.post("/WordleSolver", body);
    return data.suggestions;
  }

  formatRequestBody(guesses) {
    return {
      guesses: guesses.map((guess) => {
        return {
          word: guess.letters.join("").toLowerCase(),
          colors: guess.colors.map((color) => {
            if (color === 1) {
              return "grey";
            } else if (color === 2) {
              return "yellow";
            } else {
              return "green";
            }
          }),
        };
      }),
    };
  }
}

export default BackendConnector;
