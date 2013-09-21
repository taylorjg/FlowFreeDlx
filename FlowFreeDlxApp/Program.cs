using System;
using System.Linq;
using DlxLib;
using FlowFreeDlx;

namespace FlowFreeDlxApp
{
    internal class Program
    {
        private static void Main()
        {
            var grid = new Grid(7, 7, new[]
                {
                    new ColourPair(new Coords(6, 6), new Coords(5, 0), "A"),
                    new ColourPair(new Coords(5, 5), new Coords(1, 4), "B"),
                    new ColourPair(new Coords(6, 5), new Coords(4, 1), "C"),
                    new ColourPair(new Coords(3, 3), new Coords(2, 2), "D"),
                    new ColourPair(new Coords(4, 3), new Coords(6, 0), "E"),
                    new ColourPair(new Coords(4, 2), new Coords(5, 1), "F")
                });

            GridPrinter.Print(grid);

            var matrixBuilder = new MatrixBuilder();
            var matrix = matrixBuilder.BuildMatrixFor(grid);

            var dlx = new Dlx();
            var solutions = dlx.Solve(matrix);

            foreach (var solution in solutions)
            {
                var solvedGrid = new Grid(7, 7, solution.RowIndexes.Select(matrixBuilder.GetColourPairAndPathForRowIndex).ToArray());
                Console.WriteLine();
                GridPrinter.Print(solvedGrid);
            }
        }
    }
}
