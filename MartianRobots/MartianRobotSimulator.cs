namespace MartianRobots;

/// <summary>
/// Simulates the movement of robots on Mars according to instructions.
/// </summary>
public class MartianRobotSimulator
{
    public List<string> ProcessInput(string input)
    {
        var lines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries)
            .Select(line => line.Trim())
            .ToList();

        if (lines.Count < 1)
            return new List<string>();

        // Parse grid dimensions
        var gridDimensions = lines[0].Split(' ');
        int maxX = int.Parse(gridDimensions[0]);
        int maxY = int.Parse(gridDimensions[1]);
        var grid = new Grid(maxX, maxY);
        var results = new List<string>();

        // Process robots
        for (int i = 1; i < lines.Count; i += 2)
        {
            if (i + 1 >= lines.Count)
                break;

            // Parse robot initial position
            var positionParts = lines[i].Split(' ');
            int x = int.Parse(positionParts[0]);
            int y = int.Parse(positionParts[1]);
            var orientation = Enum.Parse<Orientation>(positionParts[2]);

            var initialPosition = new RobotPosition(x, y, orientation);
            var robot = new Robot(initialPosition, grid);

            // Execute instructions
            string instructions = lines[i + 1];
            robot.ExecuteInstructions(instructions);

            // Collect result
            results.Add(robot.ToString());
        }

        return results;
    }
}
