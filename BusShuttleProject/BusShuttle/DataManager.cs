namespace BusShuttle;

public class DataManager 
{
    FileSaver fileSaver;

    public List<Loop> Loops { get; }
    public List<Stop> Stops { get; }
    public List<Driver> Drivers { get; }
    public List<PassengerData> PassengerData { get; }

    public DataManager()
    // prof uses List.Add() to add to list object, but I prefer literals as I think they are cleaner
    {

        fileSaver = new FileSaver("passenger-data.txt");

        Loops = new List<Loop>
        {
            new Loop("Red"),
            new Loop("Green"),
            new Loop("Blue"),
        };

        Stops = new List<Stop>
        {
            new Stop("Music"), 
            new Stop("Tower"), 
            new Stop("Oakwood"), 
            new Stop("Anthony"), 
            new Stop("Letterman"),
        };

        Loops[0].Stops.AddRange(new List<Stop>
        // does not yet include stops for Green or Blue loops yet, for some reason...
        {
            Stops[0],
            Stops[1],
            Stops[2],
            Stops[3],
            Stops[4],
        });

        Drivers = new List<Driver>
        {
            new Driver("David Turner"),
            new Driver("Jane Doe"),
        };

        PassengerData = new List<PassengerData>();
    }

    public void AddNewPassengerData(PassengerData data)
    {
        this.PassengerData.Add(data);
        this.fileSaver.AppendData(data);
    }



}