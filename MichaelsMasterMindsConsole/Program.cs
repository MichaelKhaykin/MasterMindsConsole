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
                    Console.WriteLine(number);
                }
            }

            return number;
        }

        static void Main(string[] args)
        {
            MasterMindsNumber computerNumber = new MasterMindsNumber();
            computerNumber.CreateNumber();

            MasterMindsNumber userInput = new MasterMindsNumber();

            String[] numberNames = { "first", "second", "third", "fourth" };                       

            for (int i = 0; i < 4; i++)
            {
                int number = getNumber(String.Format("Please give me {0} number", numberNames[i]));
                bool isAddSuccessful = userInput.AddDigit(number);

                if (!isAddSuccessful)
                {
                    Console.WriteLine("It looks like we already have the number {0}; please try again.", number);
                    i--;
                }
            }

            //Compare the two MasterMindsNumnber objects
            bool didUserWin = userInput.Check(computerNumber);

            Console.WriteLine("Checking... here are the results:");
            Console.WriteLine(userInput);
        }
    }
}
