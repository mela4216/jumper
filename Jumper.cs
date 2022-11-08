using System;
using System.Collections.Generic;


namespace jumper_game
{
    /// <summary>
    /// <para>The person hiding from the Seeker.</para>
    /// <para>
    /// The responsibility of Hider is to keep track of its location and distance from the seeker.
    /// </para>
    /// </summary>
    public class Jumper
    {
        private List<string> jumper = new List<string>();
        private int count;
        private int trueTries = 0;

        /// <summary>
        /// Constructs a new instance of Hider. 
        /// </summary>
        public Jumper()
        {
            // start with two so GetHint always works

            jumper.Add(@" ___");
            jumper.Add(@"/___\");
            jumper.Add(@"\   /");
            jumper.Add(@" \ / ");
            jumper.Add(@"  O");
            jumper.Add(@" /|\");
            jumper.Add(@" / \ ");

        }




        /// <summary>
        /// Gets a hint for the seeker.
        /// </summary>
        /// <returns>A new hint.</returns>
        public bool checkInput(List<char> guesses, string currentguess)
        {
            if (guesses.Contains(currentguess[0]))
            {
                Console.WriteLine("You already guessed that letter!");
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// Whether or not the hider has been found.
        /// </summary>
        /// <returns>True if found; false if otherwise.</returns>
        public bool checkJumper(List<char> yourGuess, int tries)
        {
            count = 0;
            for(int i=0;i<yourGuess.Count;i++)
            {
                if (yourGuess[i] != '_')
                {
                    count++;
                }
                else
                {

                }
            }
            if (count == yourGuess.Count)
            {
                return false;
            }
            else if(tries == 4)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        


        /// <summary>
        /// Watches the seeker by keeping track of how far away it is.
        /// </summary>
        /// <param name="seeker">The seeker to watch.</param>
        public void showJumper(int tries)
        {
            if(tries == trueTries)
            {

            }
            else if(tries == 4)
            {
                jumper.RemoveRange(0,1);
                jumper[0] = "  X";
            }
            else
            {
                jumper.RemoveRange(0,1);
                trueTries++;
            }
            Console.WriteLine(string.Format("{0}", string.Join("\n", jumper)));
        }
    }
}