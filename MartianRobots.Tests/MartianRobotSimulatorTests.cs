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

    [Fact]
public void HandlesSampleDataCorrectly()
{
    var simulator = new MartianRobotSimulator();
    string input = """
    5 3
    1 1 E
    RFRFRFRF
    3 2 N
    FRRFLLFFRRFLL
    0 3 W
    LLFFFLFLFL
    """;
    
    var results = simulator.ProcessInput(input);
    
    Assert.Equal(3, results.Count);
    Assert.Equal("1 1 E", results[0]);
    Assert.Equal("3 3 N LOST", results[1]);
    Assert.Equal("2 3 S", results[2]);
}



[Fact]
public void HandlesRobotAtOrigin()
{
    var simulator = new MartianRobotSimulator();
    string input = """
    5 5
    0 0 N
    FFF
    """;
    
    var results = simulator.ProcessInput(input);
    
    Assert.Single(results);
    Assert.Equal("0 3 N", results[0]);
}

[Fact]
public void HandlesComplexInstructions()
{
    var simulator = new MartianRobotSimulator();
    string input = """
    10 10
    5 5 N
    RFLFLFLFF
    """;
    
    var results = simulator.ProcessInput(input);
    
    Assert.Single(results);
    // R: facing E, F: (6,5), L: facing N, F: (6,6), L: facing W, F: (5,6), L: facing S, F: (5,5), F: (5,4)
    Assert.Equal("5 4 S", results[0]);
}
}