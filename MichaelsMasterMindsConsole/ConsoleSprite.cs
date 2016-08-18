using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    public class ConsoleSprite
    {
        public string[] Texture { get; set; }

        public Point Position { get; set; }

        public ConsoleColor Color { get; set; }


        public ConsoleSprite(string[] texture, Point position, ConsoleColor color)
        {
            this.Color = color;
            this.Texture = texture;
            this.Position = position;
        }

        public void Draw()
        {
            Console.ForegroundColor = Color;

            for (int i = 0; i < Texture.Length; i++)
            {
                Console.SetCursorPosition(Position.X, Position.Y + i);
                Console.Write(Texture[i]);
            }
            
        }
    }
}
