namespace BusShuttle;

using Spectre.Console;

public class ConsoleUI
{
    FileSaver fileSaver;

    List<Loop> loops;
    List<Stop> stops;
    List<Driver> drivers;

    public ConsoleUI()                      // constructor
    {
        fileSaver = new FileSaver("passenger-data.txt");

        loops = new List<Loop>();
        loops.Add(new Loop("Red"));
        loops.Add(new Loop("Green"));
        loops.Add(new Loop("Blue"));

        // Could do the same as above, but I'd rather use literal
        stops = new List<Stop>
        {
            new Stop("Music"), 
            new Stop("Tower"), 
            new Stop("Oakwood"), 
            new Stop("Anthony"), 
            new Stop("Letterman")
        };

        // loops[0].Stops.Add(stops[0]);
        // loops[0].Stops.Add(stops[1]);
        // loops[0].Stops.Add(stops[2]);
        // loops[0].Stops.Add(stops[3]);
        // loops[0].Stops.Add(stops[4]);

        // Above is how prof wrote this, but quite ugly, I prefer literal again
        loops[0].Stops.AddRange(new List<Stop>
        {
            stops[0],
            stops[1],
            stops[2],
            stops[3],
            stops[4],
        });

        drivers = new List<Driver>
        {
            new Driver("David Turner"),
            new Driver("Jane Doe"),
        };

    }

    public void Show()
    {

        var mode = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Please select mode")
                .AddChoices(new[] {
                    "driver", "manager"                
                }));

        if (mode == "driver")
        {

            Driver selectedDriver = AnsiConsole.Prompt(
                new SelectionPrompt<Driver>()
                    .Title("Select a driver")
                    .AddChoices(drivers));
            Console.WriteLine("You are driving as " + selectedDriver.Name);

            Loop selectedLoop = AnsiConsole.Prompt(
                new SelectionPrompt<Loop>()
                    .Title("Select a loop")
                    .AddChoices(loops));
            Console.WriteLine("You selected " + selectedLoop.Name + " loop");

            string command;

            do 
            {

                Stop selectedStop = AnsiConsole.Prompt(
                    new SelectionPrompt<Stop>()
                        .Title("Select a stop")
                        .AddChoices(selectedLoop.Stops));
                Console.WriteLine("You selected " + selectedStop.Name + " stop");

                int boarded = int.Parse(AskForInput("Enter number of boarded passengers: "));
                
                PassengerData data = new PassengerData(boarded, selectedStop, selectedLoop, selectedDriver);
                fileSaver.AppendData(data);

                command = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("What's next?")
                        .AddChoices(new[] {
                            "continue", "end"                
                        }));

            } while (command != "end");
        }
    }

    public static string AskForInput (string message)
    {
        Console.Write(message);
        return Console.ReadLine();
    }
}