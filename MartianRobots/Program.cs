namespace MartianRobots;

class Program
{
    static void Main(string[] args)
    {
        var simulator = new MartianRobotSimulator();

        Console.WriteLine("=== Martian Robots Simulator ===\n");
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Use sample data");
        Console.WriteLine("2. Enter custom input");
        Console.Write("\nEnter your choice (1 or 2): ");

        string choice = Console.ReadLine() ?? "1";

        string input;

        if (choice == "2")
        {
            Console.WriteLine("\nEnter your grid and robot data (press Enter twice when done):");
            Console.WriteLine("Format: First line = grid dimensions (e.g., '5 3')");
            Console.WriteLine("Then pairs of lines: position/orientation and instructions\n");
            
            var lines = new List<string>();
            string? line;
            int emptyLineCount = 0;
            
            while (emptyLineCount < 1)
            {
                line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    emptyLineCount++;
                }
                else
                {
                    emptyLineCount = 0;
                    lines.Add(line);
                }
            }
            input = string.Join("\n", lines);
        }
        else
        {
            // Sample data from the problem statement
            input = """
            5 3
            1 1 E
            RFRFRFRF
            3 2 N
            FRRFLLFFRRFLL
            0 3 W
            LLFFFLFLFL
            """;
            
            Console.WriteLine("Using sample data:\n");
        }

        Console.WriteLine("\n=== Results ===\n");
        var results = simulator.ProcessInput(input);

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}

