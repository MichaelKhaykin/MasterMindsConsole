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
        public static int GetNumber(string message, char min = '0', char max = '9')
        {
            Console.Write(message);
            int number = -1;

            //ASCII values for numbers 0 through 9 are 48 through 57
            while (number == -1)
            {
                char pressedKey = Console.ReadKey(true).KeyChar;

                if (pressedKey <= max && pressedKey >= min)
                {
                    number = int.Parse(pressedKey.ToString());
                }
            }

            return number;
        }

        static void Main(string[] args)
        {
            MasterMindsBase game;

            Console.OutputEncoding = Encoding.Unicode;

            while (true)
            {
                //Setting the background to DarkCyan
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.Clear();

                //Display a menu
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("MasterMinds game");
                Console.WriteLine("--------------------");
                Console.WriteLine("1) Text version");
                Console.WriteLine("2) Graphical version");
                Console.WriteLine("3) Exit");
                Console.WriteLine();
                int choice = GetNumber("Enter selection => ", '1', '3');

                Console.Clear();
                switch (choice)
                {
                    case 1:
                        game = new MasterMindsText();
                        game.Play();
                        break;

                    case 2:
                        Console.CursorVisible = false;
                        game = new GraphicalMasterMinds();
                        game.Play();
                        Console.ReadKey(true);
                        break;

                    case 3:
                        return;
                }
            }
        }

    }
}
