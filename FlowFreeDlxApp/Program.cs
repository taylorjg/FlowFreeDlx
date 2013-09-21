using FlowFreeDlx;

namespace FlowFreeDlxApp
{
    internal class Program
    {
        private static void Main()
        {
            var initStrings = new[]
                {
                    "------A",
                    "-----BC",
                    "-B-----",
                    "---DE--",
                    "--D-F--",
                    "----CF-",
                    "-----AE"
                };

            var grid = new Grid(initStrings);

            var gridPrinter = new GridPrinter(new ConsolePrintTarget());
            gridPrinter.Print(grid);
        }
    }
}
