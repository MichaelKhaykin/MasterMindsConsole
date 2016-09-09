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

        public int Height
        {
            get
            {
                if(Texture != null)
                { 
                    return Texture.Length;
                }
                else
                {
                    return 0;
                }
            }
        }

        public int Width
        {
            get
            {
                int longestString = 0;

                if (Texture != null)
                {
                    //Find and return the length of the longest string
                    //Make an int that's called "longestString", and start it with zero
                    //Loop through the Texture string array; compare the length of EACH string in the array to longestString;
                    //IF the string length is greater, set the longestString variable equal to that length; otherwise, do nothing
                    //After you're done with the loop, return longestString
                 
                    for (int i = 0; i < Texture.Length; i++)
                    {
                        if (Texture[i].Length > longestString)
                        {
                            longestString = Texture[i].Length;
                        }
                                      
                    }
                }

                return longestString;
            }
        }

        public ConsoleSprite(string[] texture, Point position, ConsoleColor color)
        {
            this.Color = color;
            this.Texture = texture;
            this.Position = position;
        }

        public virtual void Draw()
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
