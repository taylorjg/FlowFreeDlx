using System;

namespace FlowFreeDlx
{
    public class GridPrinter
    {
        public void Print(Grid grid)
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

                    var cellContents = grid.CellContents(new Coords(x, y));
                    if (cellContents != null)
                    {
                        var ch = cellContents[0];
                        ChangeConsoleForegroundColorIf(
                            true,
                            ConsoleColor.Blue,
                            () => Console.Write(" {0} ", ch));
                    }
                    else
                    {
                        Console.Write(new string(' ', 3));
                    }
                }
                Console.Write("|");
                Console.WriteLine();
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

        // Black
        // Blue
        // Cyan
        // DarkBlue
        // DarkCyan
        // DarkGray
        // DarkGreen
        // DarkMagenta
        // DarkRed
        // DarkYellow
        // Gray
        // Green
        // Magenta
        // Red
        // White
        // Yellow

        private static void ChangeConsoleForegroundColorIf(bool condition, ConsoleColor consoleColor, Action action)
        {
            var oldForegroundColor = Console.ForegroundColor;

            if (condition)
            {
                Console.ForegroundColor = consoleColor;
            }

            action();

            if (condition)
            {
                Console.ForegroundColor = oldForegroundColor;
            }
        }
    }
}
