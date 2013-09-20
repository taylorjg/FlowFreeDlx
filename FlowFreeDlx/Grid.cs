using System;
using System.Linq;

namespace FlowFreeDlx
{
    public class Grid
    {
        private readonly string[,] _cells;
        public int Width { get; private set; }
        public int Height { get; private set; }

        public Grid(string[] initStrings)
        {
            if (initStrings.Length == 0)
            {
                throw new ArgumentException("At least one initialisation string must be provided.", "initStrings");
            }

            Width = initStrings[0].Length;
            Height = initStrings.Length;

            if (initStrings.Any(s => s.Length != Width))
            {
                throw new ArgumentException("Initialisation strings must all have the same length.", "initStrings");
            }

            _cells = new string[Width,Height];

            for (var y = 0; y < Height; y++)
            {
                var s = initStrings[y];

                for (var x = 0; x < Width; x++)
                {
                    var ch = s[x];
                    switch (ch)
                    {
                        case ' ':
                            break;

                        case 'A':
                        case 'B':
                        case 'C':
                        case 'D':
                        case 'E':
                        case 'F':
                        case 'G':
                        case 'H':
                        case 'I':
                        case 'J':
                            _cells[x, Height - y - 1] = Convert.ToString(ch);
                            break;

                        default:
                            throw new InvalidOperationException(String.Format("Invalid character in initStrings, '{0}'.", ch));
                    }
                }
            }
        }

        public bool IsCellOccupied(Coords coords)
        {
            return _cells[coords.X, coords.Y] != null;
        }

        public bool CoordsAreOffTheGrid(Coords coords)
        {
            return
                coords.X < 0 ||
                coords.Y < 0 ||
                coords.X >= Width ||
                coords.Y >= Height;
        }
    }
}
