using MartianRobots;
using Xunit;

namespace MartianRobots.Tests;

public class RobotTests
{
    [Fact]
    public void RobotStartsAtInitialPosition()
    {
        var grid = new Grid(5, 5);
        var position = new RobotPosition(1, 1, Orientation.N);
        var robot = new Robot(position, grid);
        
        Assert.Equal("1 1 N", robot.ToString());
    }

    [Fact]
    public void RobotMovesForwardNorth()
    {
        var grid = new Grid(5, 5);
        var position = new RobotPosition(1, 1, Orientation.N);
        var robot = new Robot(position, grid);
        
        robot.ExecuteInstructions("F");
        
        Assert.Equal("1 2 N", robot.ToString());
    }

    [Fact]
    public void RobotMovesForwardEast()
    {
        var grid = new Grid(5, 5);
        var position = new RobotPosition(2, 2, Orientation.E);
        var robot = new Robot(position, grid);
        
        robot.ExecuteInstructions("F");
        
        Assert.Equal("3 2 E", robot.ToString());
    }

    [Fact]
    public void RobotTurnsLeft()
    {
        var grid = new Grid(5, 5);
        var position = new RobotPosition(2, 2, Orientation.N);
        var robot = new Robot(position, grid);
        
        robot.ExecuteInstructions("L");
        
        Assert.Equal("2 2 W", robot.ToString());
    }

    [Fact]
    public void RobotTurnsAndMoves()
    {
        var grid = new Grid(5, 5);
        var position = new RobotPosition(2, 2, Orientation.N);
        var robot = new Robot(position, grid);
        
        robot.ExecuteInstructions("RF");
        
        Assert.Equal("3 2 E", robot.ToString());
    }

    [Fact]
    public void RobotMovesMultipleSteps()
    {
        var grid = new Grid(5, 5);
        var position = new RobotPosition(1, 1, Orientation.E);
        var robot = new Robot(position, grid);
        
        robot.ExecuteInstructions("FFF");
        
        Assert.Equal("4 1 E", robot.ToString());
    }

   
}