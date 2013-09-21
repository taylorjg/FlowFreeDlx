using System;
using System.Collections.Generic;

namespace FlowFreeDlx
{
    public class Grid
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        public IEnumerable<ColourPair> ColourPairs { get; private set; }
        private readonly string[,] _cells;

        public Grid(int width, int height, params ColourPair[] colourPairs)
        {
            Width = width;
            Height = height;
            ColourPairs = colourPairs;
            _cells = new string[Width, Height];

            foreach (var colourPair in colourPairs)
            {
                switch (colourPair.Tag)
                {
                    case "A":
                    case "B":
                    case "C":
                    case "D":
                    case "E":
                    case "F":
                        _cells[colourPair.StartCoords.X, colourPair.StartCoords.Y] = colourPair.Tag;
                        _cells[colourPair.EndCoords.X, colourPair.EndCoords.Y] = colourPair.Tag;
                        break;

                    default:
                        throw new InvalidOperationException(String.Format("Unknown tag, '{0}'.", colourPair.Tag));
                }
            }
        }

        public bool IsCellOccupied(Coords coords)
        {
            return _cells[coords.X, coords.Y] != null;
        }

        public string GetTagAtCoords(Coords coords)
        {
            return _cells[coords.X, coords.Y];
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
