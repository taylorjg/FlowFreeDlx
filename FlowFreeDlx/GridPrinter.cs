namespace FlowFreeDlx
{
    public class GridPrinter
    {
        private readonly IPrintTarget _printTarget;

        public GridPrinter(IPrintTarget printTarget)
        {
            _printTarget = printTarget;
        }

        public void Print(Grid grid)
        {
            // Note that the outer loop iterates over the rows rather than the columns
            // because it is easier to build the lines this way. Also, we regard (0,0)
            // to be in the bottom left corner. Hence, we print the highest numbered
            // row first so that the last row printed will be row 0.

            var rowDivider = GetRowDivider(grid);

            for (var y = grid.Height - 1; y >= 0; y--)
            {

                _printTarget.PrintLine(rowDivider);

                var line = string.Empty;

                // The inner loop iterates over the columns.
                for (var x = 0; x < grid.Width; x++)
                {
                    line += "|";

                    var cellContents = grid.CellContents(new Coords(x, y));
                    if (cellContents != null)
                    {
                        var ch = cellContents[0];
                        line += string.Format(" {0} ", ch);
                    }
                    else
                    {
                        line += new string(' ', 3);
                    }
                }
                line += "|";

                _printTarget.PrintLine(line);
            }

            _printTarget.PrintLine(rowDivider);
        }

        public string GetRowDivider(Grid grid)
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
    }
}
