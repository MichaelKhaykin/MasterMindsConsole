using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    /// <summary>
    /// Keeps track of the 4 digits that either the computer or the user picked
    /// </summary>
    public class MasterMindsNumber
    {

        MasterMindsDigit[] numbersArray = new MasterMindsDigit[4];

        public void CreateNumber()
        {
            Random rand = new Random();
            int firstNumber = rand.Next(1, 10);

            MasterMindsDigit firstDigit = new MasterMindsDigit(firstNumber, DigitStates.Right);
            numbersArray[0] = firstDigit;


            for (int i = 1; i < 4; i++)
            {
                int newNumber = rand.Next(0, 10);

                if (this.contains(newNumber))
                {
                    i--;
                    continue;
                }
                //if it comes to this point the number is unique

                MasterMindsDigit uniqueNumber = new MasterMindsDigit(newNumber, DigitStates.Right);
                numbersArray[i] = uniqueNumber;
            }
        }

        private bool contains(int number)
        {
            bool doesContain = false;

            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] != null)
                {
                    if (numbersArray[i].Number == number)
                    {
                        doesContain = true;
                        break;
                    }
                }
            }
            return doesContain;
        }

    }
}
