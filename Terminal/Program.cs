using Terminal.Logic;

namespace Terminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string? rawInput = Console.ReadLine();
                try
                {
                    Command command = new(rawInput);
                    var outputLines = command.Execute();
                    foreach (string line in outputLines)
                        Console.WriteLine(line);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}