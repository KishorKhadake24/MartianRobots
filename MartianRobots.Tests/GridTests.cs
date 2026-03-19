using MartianRobots;
using Xunit;

namespace MartianRobots.Tests;

public class GridTests
{
    [Fact]
    public void GridIsWithinBounds()
    {
        var grid = new Grid(5, 3);
        Assert.True(grid.IsWithinBounds(0, 0));
        Assert.True(grid.IsWithinBounds(5, 3));
        Assert.False(grid.IsWithinBounds(6, 3));
        Assert.False(grid.IsWithinBounds(-1, 2));
    }

    [Fact]
    public void GridStartsWithNoScents()
    {
        var grid = new Grid(5, 3);
        Assert.False(grid.HasScent(3, 2));
    }

    [Fact]
    public void GridHasScentAfterAdding()
    {
        var grid = new Grid(5, 3);
        grid.AddScent(3, 2);
        Assert.True(grid.HasScent(3, 2));
    }

    [Fact]
    public void GridTracksMultipleScents()
    {
        var grid = new Grid(5, 3);
        grid.AddScent(1, 1);
        grid.AddScent(3, 2);
        grid.AddScent(5, 3);
        
        Assert.True(grid.HasScent(1, 1));
        Assert.True(grid.HasScent(3, 2));
        Assert.True(grid.HasScent(5, 3));
        Assert.False(grid.HasScent(2, 2));
    }
}