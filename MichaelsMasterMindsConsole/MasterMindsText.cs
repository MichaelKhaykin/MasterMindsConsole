using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    public class MasterMindsText : MasterMindsBase
    {
        public override void Play()
        {
            string emptyLine = new string(' ', 60);

            int tries = 0;
            Console.ForegroundColor = ConsoleColor.White;

            ComputerNumber.CreateNumber();

            String[] numberNames = { "first", "second", "third", "fourth" };
            bool didUserWin = false;

            Console.CursorVisible = false;

            do
            {

                tries++;
                MasterMindsNumber userInput = new MasterMindsNumber();
                //Clearing lines so new numbers could be entered
                Console.SetCursorPosition(0, 1);
                Console.WriteLine(emptyLine);
                Console.WriteLine(emptyLine);

                for (int i = 0; i < 5; i++)
                {
                    int number = 0;
                    //Just setting it to the top (0, 0)
                    Console.SetCursorPosition(0, 0);
                    if (i != 4)
                    {

                        number = Program.GetNumber(String.Format("Please give me {0} number                    \n",
                             numberNames[i]));
                    }
                    else
                    {
                        number = Program.GetNumber("If you're done then please press enter.                     \n");
                    }

                    if (number == Program.BACKSPACE_KEY)
                    {
                        //First key pressed was backspace; ignore, but set i back so we don't lose a digit...
                        if (i == 0)
                        {
                            i--;
                            continue;
                        }

                        i--;    //Set i back by 1, as current "digit" was a backspace key

                        userInput.RemoveLastDigit();

                        Console.SetCursorPosition(i, 1);
                        Console.Write(" ");
                        Console.CursorLeft--;

                        i--;    //Set i back by 1 again, as we just removed a digit, and need the user to re-enter it.
                        continue;
                    }

                    else if (number == Program.ENTER_KEY)
                    {
                        i--;
                        break;
                    }

                    if (i < 4)
                    {
                        bool isAddSuccessful = userInput.AddDigit(number);


                        if (!isAddSuccessful)
                        {

                            //Setting 2 lines down
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine("It looks like we already have the number {0}; please try again.", number);
                            i--;
                        }
                        else
                        {
                            //Setting it to the position of the current number
                            Console.SetCursorPosition(i, 1);
                            Console.WriteLine(number);
                            Console.WriteLine(emptyLine);
                        }
                    }
                    else
                    {
                        i--;
                    }
                }

                //Compare the two MasterMindsNumnber objects
                didUserWin = userInput.Check(ComputerNumber);


                //This is the checking setting it 5 lines down
                Console.SetCursorPosition(0, 5);
                Console.ForegroundColor = ConsoleColor.Yellow;
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(emptyLine);
                }
                //This is making the checking results Yellow and then once were ready to continue it becomes gray
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Checking... here are the results:");
                Console.WriteLine(userInput);
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("Press any key to try again...");
                Console.ReadKey(true);

                //This is just making the checking gray by rewriting it on the same lines but gray
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("Checking... here are the results:");
                Console.WriteLine(userInput);
                Console.ForegroundColor = ConsoleColor.White;

                //Erases the "Press any key to try again" 
                Console.SetCursorPosition(0, 11);
                Console.WriteLine(emptyLine);

            } while (!didUserWin);

            Console.WriteLine(String.Format("Congratulations! You win! It took you {0} tries.", tries));
            Console.ReadKey();

        }
    }
}
