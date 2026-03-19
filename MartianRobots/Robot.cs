namespace MartianRobots;

/// <summary>
/// Represents a robot that can move on the grid and execute instructions.
/// </summary>
public class Robot
{
    private RobotPosition _currentPosition;
    private bool _isLost;
    private readonly Grid _grid;

    public RobotPosition CurrentPosition => _currentPosition;
    public bool IsLost => _isLost;

    public Robot(RobotPosition initialPosition, Grid grid)
    {
        _currentPosition = initialPosition;
        _grid = grid;
        _isLost = false;
    }

    public void ExecuteInstructions(string instructions)
    {
        foreach (char instruction in instructions)
        {
            if (_isLost)
                break;

            ExecuteInstruction(instruction);
        }
    }

    private void ExecuteInstruction(char instruction)
    {
        switch (instruction)
        {
            case 'L':
                TurnLeft();
                break;
            case 'R':
                TurnRight();
                break;
            case 'F':
                MoveForward();
                break;
            default:
                throw new InvalidOperationException($"Unknown instruction: {instruction}");
        }
    }

    private void TurnLeft()
    {
        _currentPosition = _currentPosition with
        {
            Orientation = _currentPosition.Orientation.TurnLeft()
        };
    }

    private void TurnRight()
    {
        _currentPosition = _currentPosition with
        {
            Orientation = _currentPosition.Orientation.TurnRight()
        };
    }

    private void MoveForward()
    {
        var (dx, dy) = _currentPosition.Orientation.GetDirection();
        int newX = _currentPosition.X + dx;
        int newY = _currentPosition.Y + dy;

        if (!_grid.IsWithinBounds(newX, newY))
        {
            // Check if there's a scent at the current position
            if (_grid.HasScent(_currentPosition.X, _currentPosition.Y))
            {
                // Ignore the move
                return;
            }

            // Robot is lost
            _isLost = true;
            _grid.AddScent(_currentPosition.X, _currentPosition.Y);
        }
        else
        {
            // Move within bounds
            _currentPosition = _currentPosition with
            {
                X = newX,
                Y = newY
            };
        }
    }

    public override string ToString() =>
        _isLost ? $"{_currentPosition} LOST" : _currentPosition.ToString();
}
