using System;
using System.Collections.Generic;
namespace jumper_game
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private Jumper jumper = new Jumper();
        private bool _isPlaying = true;
        public SecretWord secretWord = new SecretWord();
        public int numberOfGuesses = 0;
        public int tries = 0;
        private TerminalService _terminalService = new TerminalService();
        private bool checkInput;
        private string chosenWord;
        List<char> guessedLetters = new List<char>();
        public string currentGuess = "test";
        /// <summary>
        /// Constructs a new instance of Director.
        /// </summary>
        public Director()
        {

        }

        /// <summary>
        /// Starts the game by running the main game loop.
        /// </summary>
        public void StartGame()
        {
            GamePrep();
            while (_isPlaying)
            {
                GetInputs();
                DoUpdates();
                DoOutputs();
            }
        }

        /// <summary>
        /// Moves the seeker to a new location.
        /// </summary>
        private void GamePrep()
        {
            chosenWord = secretWord.pullWord();
            secretWord.listWord(chosenWord);
            secretWord.createSecretWord();
            secretWord.showGuess();
        }

        // Under GetInputs(), we need to prompt the user for 
        // a letter of their choosing
        // We will save this letter as yourGuess
        private void GetInputs()
        {
            jumper.showJumper(tries);
            checkInput = true;
            while(checkInput)
            {
                currentGuess = _terminalService.ReadGuess("Guess a letter: ");
                checkInput = jumper.checkInput(guessedLetters, currentGuess);
            }
            guessedLetters.Add(currentGuess[0]);
        }

        /// <summary>
        /// Keeps watch on where the seeker is moving.
        /// </summary>

        // In DoUpdates, we will check to see if the letter
        // is in the word.
        // If the letter is included, we will replace the "_"
        // with the letter.
        // If the letter is not included, we will keep the hint
        // as is.
        private void DoUpdates()
        {
            numberOfGuesses = guessedLetters.Count;
            int usedTries = secretWord.compare(guessedLetters, numberOfGuesses);
            tries = tries + usedTries;
            _isPlaying = jumper.checkJumper(secretWord.guess, tries);
        }

        /// <summary>
        /// Provides a hint for the seeker to use.
        /// </summary>


        // For DoOutputs(),  we will tell the user if their choices
        // right or wrong. From there, we will tell the winner if 
        // they win or lose, depending on if they were able to 
        // guess the word in times.
        private void DoOutputs()
        {


            // if the letter chosen matches the secret word, replace the "_" with
            // the correct letter
            // if the letter chosen does not match, keep the hint as is
            if (_isPlaying)
            {
                secretWord.showGuess();
            }
            else
            {
                jumper.showJumper(tries);
                secretWord.printAnswer();
            }
            
        }
    }
}