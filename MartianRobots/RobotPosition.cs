namespace MartianRobots;

/// <summary>
/// Represents a robot's position and orientation on the grid.
/// </summary>
public record RobotPosition(int X, int Y, Orientation Orientation)
{
    public override string ToString() =>
        $"{X} {Y} {Orientation}";
}

/// <summary>
/// Represents the four cardinal directions.
/// </summary>
public enum Orientation
{
    N, E, S, W
}

/// <summary>
/// Extension methods for orientation operations.
/// </summary>
public static class OrientationExtensions
{
    public static Orientation TurnLeft(this Orientation orientation) =>
        orientation switch
        {
            Orientation.N => Orientation.W,
            Orientation.W => Orientation.S,
            Orientation.S => Orientation.E,
            Orientation.E => Orientation.N,
            _ => throw new InvalidOperationException($"Unknown orientation: {orientation}")
        };

    public static Orientation TurnRight(this Orientation orientation) =>
        orientation switch
        {
            Orientation.N => Orientation.E,
            Orientation.E => Orientation.S,
            Orientation.S => Orientation.W,
            Orientation.W => Orientation.N,
            _ => throw new InvalidOperationException($"Unknown orientation: {orientation}")
        };

    public static (int dx, int dy) GetDirection(this Orientation orientation) =>
        orientation switch
        {
            Orientation.N => (0, 1),
            Orientation.S => (0, -1),
            Orientation.E => (1, 0),
            Orientation.W => (-1, 0),
            _ => throw new InvalidOperationException($"Unknown orientation: {orientation}")
        };
}
