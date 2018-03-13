using System.Collections.Generic;

public class ProviderFactory
{
    public Provider GetNewProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];
        double energyOutput = int.Parse(arguments[2]);

        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                return null;
        }
    }
}
