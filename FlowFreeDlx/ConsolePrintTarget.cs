namespace FlowFreeDlx
{
    public class ConsolePrintTarget : IPrintTarget
    {
        public void PrintLine(string line)
        {
            System.Console.WriteLine(line);
        }
    }
}
