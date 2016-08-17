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

            MasterMindsDigit firstDigit = new MasterMindsDigit(firstNumber, DigitStates.Correct);
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

                MasterMindsDigit uniqueNumber = new MasterMindsDigit(newNumber, DigitStates.Correct);
                numbersArray[i] = uniqueNumber;
            }
        }

        /// <summary>
        /// Adds a digit to the MasterMindsNumber.
        /// </summary>
        /// <param name="number">Number to add. It will be added as an Unchecked MasterMindsDigit.</param>
        /// <returns>True if the number is unique, and there is space to add it (less than 4 numbers are entered); false otherwise</returns>
        public bool AddDigit(int number)
        {
            //MasterMindsNumber digits must be unique; checking if the number to be added is already present
            if (this.contains(number))
            {
                return false;
            }

            //Checking whether or not we have space in the array
            if (numbersArray[numbersArray.Length - 1] != null)
            {
                return false;
            }

            //Setting the first available space to a number
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] == null)
                {
                    numbersArray[i] = new MasterMindsDigit(number, DigitStates.Unchecked);
                    break;
                }
            }

            return true;
        }

        public bool Check(MasterMindsNumber correctNumber)
        {
            bool allRightAndRightSpot = true;

            for (int i = 0; i < this.numbersArray.Length; i++)
            {
                if (this.numbersArray[i].Number == correctNumber.numbersArray[i].Number)
                {
                    this.numbersArray[i].State = DigitStates.Correct;
                }
                else if (correctNumber.contains(numbersArray[i].Number))
                {
                    this.numbersArray[i].State = DigitStates.WrongSpot;
                    allRightAndRightSpot = false;
                }
                else
                {
                    this.numbersArray[i].State = DigitStates.Incorrect;
                    allRightAndRightSpot = false;
                }
            }

            return allRightAndRightSpot;
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


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.numbersArray.Length; i++)
            {
                string numberState = "";

                switch (this.numbersArray[i].State)
                {
                    case DigitStates.Correct:
                        numberState = "correct";
                        break;

                    case DigitStates.Incorrect:
                        numberState = "incorrect";
                        break;

                    case DigitStates.WrongSpot:
                        numberState = "in the wrong spot";
                        break;

                    case DigitStates.Unchecked:
                        numberState = "not yet checked";
                        break;

                }
                result.AppendLine(String.Format("Digit {0} is {1}, and is {2}   ", i + 1, this.numbersArray[i].Number, numberState));
            }

            return result.ToString();
        }
    }
}
