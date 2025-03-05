namespace BusShuttle.Tests;

using BusShuttle;

public class DataManagerTests
{
    DataManager dataManager;

    public DataManagerTests()
    {
        var nl = Environment.NewLine;
        File.WriteAllText("stops.txt", "One" + nl + "Two" + nl + "Three" + nl + "Four" + nl + "Five" + nl);
        dataManager = new DataManager();
    }

    [Fact]
    public void Test_AddStop()
    {
        Assert.Equal(5, dataManager.Stops.Count);
        dataManager.AddStop(new Stop("newStop"));
        Assert.Equal(6, dataManager.Stops.Count);
    }
}