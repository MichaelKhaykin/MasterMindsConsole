using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MichaelsMasterMindsConsole
{
    public class GraphicalMasterMinds : MasterMindsBase
    {
        public void createLegend()
        {
            string[] texture = getTexture();

            Tuple<Square, Point, string>[] legend =
            {
                new Tuple<Square, Point, string>
                (
                    new Square(texture, new Point(43, 2), ConsoleColor.Yellow),
                    new Point(25, 3),
                    "Unchecked"
                ),

                new Tuple<Square, Point, string>
                (
                    new Square(texture, new Point(43, 5), ConsoleColor.Yellow, '?', new Point(44, 6)),
                    new Point(25, 6),
                    "Correct"
                ),

                new Tuple<Square, Point, string>
                (
                     new Square(texture, new Point(43, 8), ConsoleColor.Yellow, '+', new Point(44, 9)),
                     new Point(25, 9),
                     "Wrong Spot"
                ),

                new Tuple<Square, Point, string>
                (
                     new Square(texture, new Point(43, 11), ConsoleColor.Yellow, 'X', new Point(44, 12)),
                     new Point(25, 12),
                     "Wrong"
                )
            };

            Console.SetCursorPosition(32, 0);
            Console.WriteLine("    Legend:");
            Console.SetCursorPosition(32, 1);
            Console.WriteLine("--------------");
            
            foreach (var legendPart in legend)
            {
                legendPart.Item1.Draw();
                Console.SetCursorPosition(legendPart.Item2.X + 7, legendPart.Item2.Y);
                Console.WriteLine(legendPart.Item3);
            }

        }
        public override void Play()
        {
            string[] texture = getTexture();

            string emptyLine = new string(' ', 60);
            int lineSpacing = texture.Length;

            int x = 70;
            int y = 0;
            Square[] squares = new Square[8];
            createLegend();


            squares[0] = new Square(texture, new Point(x, y), ConsoleColor.Black, 'K', new Point(x + 1, y + 1));
            y += lineSpacing;

            for (int i = 9; i < 16; i++)
            {
                //using console colors 9-16 which is 7 numbers (because we already have one so it's 8 total)
                int squareNumber = i - 8;
                ConsoleColor colorr = (ConsoleColor)i;

                Square square = new Square(texture, new Point(x, y), colorr, colorr.ToString()[0], new Point(x + 1, y + 1));
                squares[squareNumber] = square;
                y += lineSpacing;
            };

            foreach (Square square in squares)
            {
                square.Draw();
            }

            string[] emptySquareTexture = getEmptySquareTexture();
            Square emptySquare;
            emptySquare = new Square(emptySquareTexture, new Point(0, 0), ConsoleColor.Gray, '?', new Point(0, 0));
            emptySquare.IsLetterVisible = true;

            int margin = 1;
            int space = 3;

            for (int col = 0; col < 4; col++)
            {
                emptySquare.Position = new Point(col * emptySquare.Width + margin + space * col, 0);
                emptySquare.LetterPosition = new Point(col * emptySquare.Width + 1 + margin + space * col, 1);
                emptySquare.Draw();
            }

            int maxRows = 5;
            emptySquare.IsLetterVisible = false;

            for (int row = 1; row <= maxRows; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    emptySquare.Position = new Point(col * emptySquare.Width + margin + space * col, emptySquare.Height * row);
                    emptySquare.Draw();
                }
            }

            Point currentSquarePosition = new Point(margin, maxRows * emptySquare.Height);
            Square currentSelector = new Square(emptySquareTexture, currentSquarePosition, ConsoleColor.Yellow, '!', new Point(currentSquarePosition.X + 1, currentSquarePosition.Y + 1));

            currentSelector.Draw();

            //Generate random MasterMinds that the player has to guess
            ComputerNumber.CreateNumber(0, 8);

            var colorMap = new ConsoleColor[] { ConsoleColor.Black, ConsoleColor.Blue, ConsoleColor.Green, ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Magenta, ConsoleColor.Yellow, ConsoleColor.White };

            int counter = 0;
            int currentRow = maxRows;
            bool isFilled = false;

            while (true)
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                for (int i = 0; i < squares.Length; i++)
                {
                    if (pressedKey.KeyChar == squares[i].Letter || pressedKey.KeyChar - 32 == squares[i].Letter)
                    {
                        isFilled = true;

                        //TODO: This square will be lost if we clear the screen... need to add to list, once we finalize it
                        Square currentSquare = new Square(squares[i].Texture, currentSelector.Position, squares[i].Color, squares[i].Letter, new Point(squares[i].LetterPosition.X, squares[i].LetterPosition.Y));
                        currentSquare.Draw();
                        break;
                    }
                }

                if (pressedKey.Key == ConsoleKey.Enter && isFilled)
                {
                    isFilled = false;
                    counter++;
                    if (counter == 4)
                    {
                        counter = 0;
                        currentRow--;
                    }

                    if (currentRow > 0)
                    {
                        int movePerPlacedSquare = space + emptySquare.Width;
                        currentSelector.Position = new Point(margin + movePerPlacedSquare * counter, currentRow * emptySquare.Height);
                        currentSelector.LetterPosition = new Point(currentSelector.Position.X + 1, currentSelector.Position.Y + 1);
                        currentSelector.Draw();
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //Display computer's number
            DisplayComputerAnswer(squares, emptySquare, margin, space, currentSelector, colorMap);
        }

        private static string[] getEmptySquareTexture()
        {
            //TODO: Draw empty box at 0,0
            //Use chars from: https://en.wikipedia.org/wiki/Box-

            char topLeftCorner = (char)0x250E;
            char topRightCorner = (char)0x2512;
            char bottomLeftCorner = (char)0x2516;
            char bottomRightCorner = (char)0x251A;
            char horizontalLine = (char)0x2500;
            char verticalLine = (char)0x2503;

            string[] emptySquareTexture = {
                String.Concat(topLeftCorner, horizontalLine, topRightCorner),
                String.Concat(verticalLine, ' ', verticalLine),
                String.Concat(bottomLeftCorner, horizontalLine, bottomRightCorner)
            };

            return emptySquareTexture;
        }

        private void DisplayComputerAnswer(Square[] squares, Square emptySquare, int margin, int space, Square currentSelector, ConsoleColor[] colorMap)
        {
            for (int col = 0; col < 4; col++)
            {
                int colorIndex = ComputerNumber[col].Number;
                ConsoleColor color = colorMap[colorIndex];

                Point Position = new Point(col * emptySquare.Width + margin + space * col, 0);
                Square currentSquare = new Square(squares[col].Texture, currentSelector.Position, color, squares[col].Letter, new Point(squares[col].LetterPosition.X, squares[col].LetterPosition.Y));

                //Point LetterPosition = new Point(col * emptySquare.Width + 1 + margin + space * col, 1);
                currentSquare.Position = new Point(Position.X, Position.Y);
                currentSquare.Draw();
            }
        }

        private string[] getTexture()
        {
            char topBlock = (char)0x2584;
            char centerBlock = (char)0x2588;
            char bottomBlock = (char)0x2580;

            string[] texture =
            {
                new String(topBlock, 3),
                new String(centerBlock, 3),
                new String(bottomBlock, 3)
            };
            return texture;
        }
    }

}

