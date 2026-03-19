namespace MartianRobots;

/// <summary>
/// Represents the rectangular grid on Mars.
/// Tracks scent positions where robots have been lost.
/// </summary>
public class Grid
{
    private readonly HashSet<(int x, int y)> _scents = new();
    public readonly int MaxX;
    public readonly int MaxY;

    public Grid(int maxX, int maxY)
    {
        MaxX = maxX;
        MaxY = maxY;
    }

    public bool IsWithinBounds(int x, int y) =>
        x >= 0 && x <= MaxX && y >= 0 && y <= MaxY;

    public bool HasScent(int x, int y) =>
        _scents.Contains((x, y));

    public void AddScent(int x, int y) =>
        _scents.Add((x, y));
}
