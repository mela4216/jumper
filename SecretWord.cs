using System;
using System.Collections.Generic;
using System.IO;



namespace jumper_game
{
    /// <summary>
    /// <para>The person looking for the Hider.</para>
    /// <para>
    /// The responsibility of a Seeker is to keep track of its location.
    /// </para>
    /// </summary>
    public class SecretWord
    {
        public string secretWord;
        List<char> answer = new List<char>();
        public List<char> guess = new List<char>();
        

        /// <summary>
        /// Constructs a new instance of Seeker.
        /// </summary>
        public SecretWord()
        {

        }

        /// <summary>
        /// Gets the current location.
        /// </summary>
        /// <returns>The current location.</returns>
        public string pullWord()
        {
            List<string> lines = new List<string>(File.ReadLines("words.txt"));
            
            Random random = new Random();
            int randomList = random.Next(0, lines.Count);
            string chosenWord = lines[randomList];
            return chosenWord;
            
        }
        public void listWord(string ripWord)
        {
            answer.AddRange(ripWord.ToLower());
        }
        public void createSecretWord()
        {
            foreach(int i in answer)
            {
                guess.Add('_');
            }
        }

        /// <summary>
        /// Moves to the given location.
        /// </summary>
        /// <param name="location">The given location.</param>
        public void showGuess()
        {
            Console.WriteLine(string.Format("{0}", string.Join(" ", guess))); 
        }

        public int compare(List<char> listPreviousGuesses, int numberOfGuesses)
        {
            for(int i=0;i<answer.Count;i++)
            {
                if (listPreviousGuesses.Contains(answer[i]))
                {
                guess[i] = answer[i];
                }
            }
            if (answer.Contains(listPreviousGuesses[numberOfGuesses-1]))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public void printAnswer()
        {
            Console.WriteLine(string.Format("{0}", string.Join(" ", answer)));
        }
        

    }
}