using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace State_Diagrams
{

    // controller for number-guessing game:
    public class GameController
    {
        private int m;                        // user's initial guess
        private int n = -1;                   // the randomly generated response
        private Status state = Status.Start;  // how far the algorithm has progressed

        // handle  executes the next step of the game based on the current state
        // param:  s is a string representing an int
        // returns:  a tuple holding  (the new state of the game, an int to be displayed)
        public Tuple<Status, int> handle(string s)
        {
            switch (state)
            {  // check current state to decide what to do:
                case Status.Start:
                    {   // start of game: s is a user-supplied int
                        bool intOK = int.TryParse(s, out m);
                        if (intOK && m >= 0 && m <= 10)
                        {
                            n = (new Random()).Next(0, 10 - m);  // generate random int
                            state = Status.HaveMN;
                        }
                        else { state = Status.Lose; }
                        break;
                    }
                case Status.HaveMN:
                    {  // middle of game: s is user's second int guess
                        int p;
                        bool intOK = int.TryParse(s, out p);
                        if (m + n + p == 10) { state = Status.Win; }
                        else { state = Status.Lose; }
                        break;
                    }
                case Status.Win:
                    { // If you win
                        state = Status.Start;
                        break;
                    }
                    
                default: { break; }  // game is over
            }
            return new Tuple<Status, int>(state, n);
        }

    }

}
