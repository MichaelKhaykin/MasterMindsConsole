using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    /// <summary>
    /// Represents a single digit in a MasterMinds number
    /// </summary>
    public class MasterMindsDigit
    {
        public int Number { get; set; }
        public DigitStates State { get; set; } = DigitStates.Unchecked;

        public MasterMindsDigit(int number)
        {
            Number = number;
        }

        public MasterMindsDigit(int number, DigitStates state)
        {
            Number = number;
            State = state;
        }
    }
}
