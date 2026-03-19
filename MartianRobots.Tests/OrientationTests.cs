using MartianRobots;
using Xunit;

namespace MartianRobots.Tests;

public class OrientationTests
{
    [Fact]
    public void TurnLeftFromNorth()
    {
        var orientation = Orientation.N;
        var result = orientation.TurnLeft();
        Assert.Equal(Orientation.W, result);
    }

    [Fact]
    public void TurnRightFromEast()
    {
        var orientation = Orientation.E;
        var result = orientation.TurnRight();
        Assert.Equal(Orientation.S, result);
    }

    [Fact]
    public void TurnRightFromNorth()
    {
        var orientation = Orientation.N;
        var result = orientation.TurnRight();
        Assert.Equal(Orientation.E, result);
    }

    [Fact]
    public void GetDirectionNorth()
    {
        var orientation = Orientation.N;
        var (dx, dy) = orientation.GetDirection();
        Assert.Equal(0, dx);
        Assert.Equal(1, dy);
    }

    [Fact]
    public void GetDirectionEast()
    {
        var orientation = Orientation.E;
        var (dx, dy) = orientation.GetDirection();
        Assert.Equal(1, dx);
        Assert.Equal(0, dy);
    }
}