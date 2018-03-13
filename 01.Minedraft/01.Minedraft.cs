using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        DraftManager manager = new DraftManager();
        string result = string.Empty;
        string input;
        while ((input = Console.ReadLine()) != "Shutdown")
        {
            List<string> commandTolk = input.Split(new[] {' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = commandTolk[0];
            commandTolk.RemoveAt(0);

            switch (command)
            {
                case "RegisterHarvester":
                    result = manager.RegisterHarvester(commandTolk);
                    break;
                case "RegisterProvider":
                    result = manager.RegisterProvider(commandTolk);
                    break;
                case "Day":
                    result = manager.Day();
                    break;
                case "Mode":
                    result = manager.Mode(commandTolk);
                    break;
                case "Check":
                    result = manager.Check(commandTolk);
                    break;
            }

            Console.WriteLine(result);
        }

        result = manager.ShutDown();
        Console.WriteLine(result);
    }
}
