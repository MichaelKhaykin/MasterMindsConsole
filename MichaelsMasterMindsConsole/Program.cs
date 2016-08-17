using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    class Program
    {
        /// <summary>
        /// Asks the user for a digit; reads the digit and checks if it's between 0-9  
        /// </summary>
        /// <param name="message">Displays message 4 times</param>
        /// <returns>digit between 0 and 9</returns>
        static int getNumber(string message)
        {
            Console.WriteLine(message);
            int number = -1;

            //ASCII values for numbers 0 through 9 are 48 through 57
            while (number == -1)
            {
                char pressedKey = Console.ReadKey(true).KeyChar;

                if (pressedKey <= 57 && pressedKey >= 48)
                {
                    number = int.Parse(pressedKey.ToString());
                }
            }

            return number;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            char block = (char)9608; //0x2588;
            string blockLine = new string(block, 3);
            string emptyLine = new string(' ', 60);

            //Console.WriteLine($"0x2580: {(char)0x2580}\n");
            //Console.WriteLine($"0x2584: {(char)0x2584}\n");

            //Setting the background to DarkCyan
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.Clear();

            //Setting all numbers to black and setting the blocks and numbers positions
            Console.ForegroundColor = ConsoleColor.Black;
            Console.CursorLeft = 70;
            Console.WriteLine(String.Format("1: {0}", blockLine));
            Console.CursorLeft = 70;
            Console.WriteLine(String.Format("   {0}\n", blockLine));

            for (int i = 9; i < 16; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.CursorLeft = 70;
                Console.Write(String.Format("{0}:", i - 7)); 

                //using console colors 9-16 which is 7 numbers (because we already have one so it's 8 total)
                Console.ForegroundColor = (ConsoleColor)i;
                Console.CursorLeft = 70;
                Console.WriteLine(String.Format("{0}: {1}", i - 7, blockLine));
                Console.CursorLeft = 70;
                Console.WriteLine(String.Format("   {0}\n", blockLine));

                Console.WriteLine();
            };

            int tries = 0;
            Console.ForegroundColor = ConsoleColor.White;

            MasterMindsNumber computerNumber = new MasterMindsNumber();
            computerNumber.CreateNumber();

            String[] numberNames = { "first", "second", "third", "fourth" };
            bool didUserWin = false;

            do
            {
                tries++;
                MasterMindsNumber userInput = new MasterMindsNumber();

                //Clearing lines so new numbers could be entered
                Console.SetCursorPosition(0, 1);
                Console.WriteLine(emptyLine);
                Console.WriteLine(emptyLine);

                for (int i = 0; i < 4; i++)
                {
                    //Just setting it to the top (0, 0)
                    Console.SetCursorPosition(0, 0);
                    int number = getNumber(String.Format("Please give me {0} number", numberNames[i]));
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

                //Compare the two MasterMindsNumnber objects
                didUserWin = userInput.Check(computerNumber);


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
