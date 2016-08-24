using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    public class Square : ConsoleSprite
    {
        public char Letter { get; set; }
        public Point LetterPosition { get; set; }
        public bool IsLetterVisible { get; set; }

        public Square(string[] texture, Point position, ConsoleColor color, char letter)
            : base(texture, position, color)
        {
            Letter = letter;
        }

        public override void Draw()
        {
            base.Draw();
            if(IsLetterVisible)
            {
                Console.SetCursorPosition(LetterPosition.X, LetterPosition.Y);
                Console.Write(Letter);
            }
        }
    }
}
