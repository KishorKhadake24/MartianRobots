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

    [Fact]
public void RobotBecomesLostOffGridNorth()
{
    var grid = new Grid(5, 3);
    var position = new RobotPosition(5, 3, Orientation.N);
    var robot = new Robot(position, grid);
    
    robot.ExecuteInstructions("F");
    
    Assert.True(robot.IsLost);
    Assert.Equal("5 3 N LOST", robot.ToString());
}

[Fact]
public void RobotLeavesScent()
{
    var grid = new Grid(5, 3);
    var position = new RobotPosition(5, 3, Orientation.N);
    var robot = new Robot(position, grid);
    
    robot.ExecuteInstructions("F");
    
    // Grid should now have scent at (5, 3)
    Assert.True(grid.HasScent(5, 3));
}

[Fact]
public void RobotRespectsScentFromLostRobot()
{
    var grid = new Grid(5, 3);
    
    // First robot falls off
    var robot1 = new Robot(new RobotPosition(5, 3, Orientation.N), grid);
    robot1.ExecuteInstructions("F");
    Assert.True(robot1.IsLost);
    
    // Second robot tries same move but respects scent at (5, 3)
    var robot2 = new Robot(new RobotPosition(5, 3, Orientation.N), grid);
    robot2.ExecuteInstructions("F");
    
    Assert.False(robot2.IsLost);
    Assert.Equal("5 3 N", robot2.ToString());
}

[Fact]
public void RobotMovesOtherDirectionsWithScent()
{
    var grid = new Grid(5, 3);
    
    // First robot falls off east
    var robot1 = new Robot(new RobotPosition(5, 2, Orientation.E), grid);
    robot1.ExecuteInstructions("F");
    
    // Second robot can still move north from (5, 2)
    var robot2 = new Robot(new RobotPosition(5, 2, Orientation.N), grid);
    robot2.ExecuteInstructions("F");
    
    Assert.False(robot2.IsLost);
    Assert.Equal("5 3 N", robot2.ToString());
}
}
