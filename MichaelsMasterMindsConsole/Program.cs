using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    class Program
    {
        static int getNumber()
        {

            Console.WriteLine("Please give me 1 number");
            int number = 0;

            char pressedKey = Console.ReadKey().KeyChar;

            //ASCII values for numbers 0 through 9 are 48 through 57
            if (pressedKey <= 57 && pressedKey >= 48)
            {
                number = int.Parse(pressedKey.ToString());
            }
            else
            {
                //TODO: Handle invalid input (loop until number is valid)
            }


            return number;
        }

        static void Main(string[] args)
        {
            

            MasterMindsNumber computerNumber = new MasterMindsNumber();
            computerNumber.CreateNumber();

            MasterMindsNumber userInput = new MasterMindsNumber();
            //TODO: Make methods to add user input to MasterMindsNumber

            

            
            getNumber();
            //int num1 = 3;
            //int num2 = 4;
            //int num3 = 1;
            //int num4 = 8;

            //userInput.AddDigit(num1);


            //TODO: Compare the two MasterMindsNumnber objects
        }
    }
}
