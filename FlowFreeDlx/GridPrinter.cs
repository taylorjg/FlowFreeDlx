using System;

namespace FlowFreeDlx
{
    public class GridPrinter
    {
        public static void Print(Grid grid)
        {
            // Note that the outer loop iterates over the rows rather than the columns
            // because it is easier to build the lines this way. Also, we regard (0,0)
            // to be in the bottom left corner. Hence, we print the highest numbered
            // row first so that the last row printed will be row 0.

            var rowDivider = GetRowDivider(grid);

            for (var y = grid.Height - 1; y >= 0; y--)
            {
                Console.WriteLine(rowDivider);

                // The inner loop iterates over the columns.
                for (var x = 0; x < grid.Width; x++)
                {
                    Console.Write("|");

                    var tag = grid.GetTagAtCoords(new Coords(x, y));
                    if (tag != null)
                    {
                        DrawCellContaining(tag);
                    }
                    else
                    {
                        DrawEmptyCell();
                    }
                }

                Console.WriteLine("|");
            }

            Console.WriteLine(rowDivider);
        }

        private static string GetRowDivider(Grid grid)
        {
            var rowDivider = string.Empty;

            for (var x = 0; x < grid.Width; x++)
            {
                rowDivider += "+";
                rowDivider += new string('-', 3);
            }
            rowDivider += "+";

            return rowDivider;
        }

        private static void DrawCellContaining(string tag)
        {
            var consoleColour = MapTagToConsoleColour(tag);

            WriteToConsoleInColour(
                consoleColour,
                () => Console.Write(" {0} ", tag));
        }

        private static void DrawEmptyCell()
        {
            Console.Write(new string(' ', 3));
        }

        private static ConsoleColor MapTagToConsoleColour(string tag)
        {
            switch (tag)
            {
                case "A":
                    return ConsoleColor.Blue;
                case "B":
                    return ConsoleColor.Magenta;
                case "C":
                    return ConsoleColor.Red;
                case "D":
                    return ConsoleColor.Green;
                case "E":
                    return ConsoleColor.Cyan;
                case "F":
                    return ConsoleColor.Yellow;
                default:
                    throw new InvalidOperationException(string.Format("Unknown tag, '{0}'.", tag));
            }
        }

        private static void WriteToConsoleInColour(ConsoleColor consoleColor, Action action)
        {
            var oldForegroundColor = Console.ForegroundColor;
            Console.ForegroundColor = consoleColor;
            action();
            Console.ForegroundColor = oldForegroundColor;
        }
    }
}
