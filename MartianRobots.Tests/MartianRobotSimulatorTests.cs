using MartianRobots;
using Xunit;

namespace MartianRobots.Tests;

public class MartianRobotSimulatorTests
{
    [Fact]
    public void ParsesSingleRobot()
    {
        var simulator = new MartianRobotSimulator();
        string input = """
        5 5
        1 1 E
        RFRFRFRF
        """;
        
        var results = simulator.ProcessInput(input);
        
        Assert.Single(results);
        Assert.Equal("1 1 E", results[0]);
    }

    [Fact]
    public void SimulatesMultipleRobots()
    {
        var simulator = new MartianRobotSimulator();
        string input = """
        5 3
        1 1 E
        RFRFRFRF
        3 2 N
        FRRFLLFFRRFLL
        """;
        
        var results = simulator.ProcessInput(input);
        
        Assert.Equal(2, results.Count);
        Assert.Equal("1 1 E", results[0]);
        Assert.Equal("3 3 N LOST", results[1]);
    }

    [Fact]
    public void RobotsShareSameScentOnGrid()
    {
        var simulator = new MartianRobotSimulator();
        string input = """
        5 3
        3 2 N
        FRRFLLFFRRFLL
        0 3 W
        LLFFFLFLFL
        """;
        
        var results = simulator.ProcessInput(input);
        
        Assert.Equal(2, results.Count);
        Assert.Equal("3 3 N LOST", results[0]);
        // Third robot should detect scent and stop at (2,3)
        Assert.Equal("2 3 S", results[1]);
    }

   
}