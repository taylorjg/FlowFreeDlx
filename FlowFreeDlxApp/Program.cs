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
            Log("Before matrixBuilder.BuildMatrixFor()");
            var matrix = matrixBuilder.BuildMatrixFor(grid);
            Log("After matrixBuilder.BuildMatrixFor()");

            Log(string.Format("matrix.GetLength(0): {0}", matrix.GetLength(0)));
            Log(string.Format("matrix.GetLength(1): {0}", matrix.GetLength(1)));

            var dlx = new Dlx();
            Log("Before dlx.Solve()");
            var solutions = dlx.Solve(matrix);
            Log("After dlx.Solve()");

            // ReSharper disable once LoopCanBePartlyConvertedToQuery
            foreach (var solution in solutions)
            {
                var solvedGrid = new Grid(7, 7, solution.RowIndexes.Select(matrixBuilder.GetColourPairAndPathForRowIndex).ToArray());
                Console.WriteLine();
                GridPrinter.Print(solvedGrid);
            }
        }

        private static void Log(string message)
        {
            var timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
            Console.WriteLine("{0}: {1}", timestamp, message);
        }
    }
}
