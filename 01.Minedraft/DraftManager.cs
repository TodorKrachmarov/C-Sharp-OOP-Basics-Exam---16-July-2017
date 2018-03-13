using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string mode;
    private List<Harvester> harvesters;
    private List<Provider> providers;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.mode = "Full";
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
        this.providerFactory = new ProviderFactory();
        this.harvesterFactory = new HarvesterFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            this.harvesters.Add(this.harvesterFactory.GetNewHarvester(arguments));
            return $"Successfully registered {type} Harvester - {id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string RegisterProvider(List<string> arguments)
    {
        string type = arguments[0];
        string id = arguments[1];

        try
        {
            this.providers.Add(this.providerFactory.GetNewProvider(arguments));
            return $"Successfully registered {type} Provider - {id}";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }

    public string Day()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("A day has passed.");
        double dayEnergy = this.providers.Sum(p => p.EnergyOutput);
        double harvestEnergy = this.harvesters.Sum(h => h.EnergyRequirement);
        this.totalStoredEnergy += dayEnergy;
        sb.AppendLine($"Energy Provided: {dayEnergy}");
        if (this.mode.ToLower() == "full")
        {
            //All Harvesters consume their FULL energy requirements, and produce their FULL ore output
            if (this.totalStoredEnergy < harvestEnergy)
            {
                sb.AppendLine("Plumbus Ore Mined: 0");
            }
            else
            {
                this.totalStoredEnergy -= harvestEnergy;
                double oreMined = this.harvesters.Sum(h => h.OreOutput);
                this.totalMinedOre += oreMined;
                sb.AppendLine($"Plumbus Ore Mined: {oreMined}");
            }

        }
        else if (this.mode.ToLower() == "half")
        {
            //All Harvesters consume 60 % of their energy requirements, and produce 50 % of their ore output
            harvestEnergy = (harvestEnergy * 60) / 100;
            if (this.totalStoredEnergy < harvestEnergy)
            {
                sb.AppendLine("Plumbus Ore Mined: 0");
            }
            else
            {
                this.totalStoredEnergy -= harvestEnergy;
                double oreMined = this.harvesters.Sum(h => h.OreOutput);
                oreMined = (oreMined * 50) / 100;
                this.totalMinedOre += oreMined;
                sb.AppendLine($"Plumbus Ore Mined: {oreMined}");
            }
        }
        else if (this.mode.ToLower() == "energy")
        {
            //The Harvesters consume nothing, and produce nothing. They practically do NOT work
            sb.AppendLine("Plumbus Ore Mined: 0");
        }
        return sb.ToString().Trim();
    }

    public string Mode(List<string> arguments)
    {
        string mode = arguments[0];
        this.mode = mode;
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(List<string> arguments)
    {
        string id = arguments[0];
        if (!this.providers.Any(p => p.Id == id) && !this.harvesters.Any(h => h.Id == id))
        {
            return $"No element found with id - {id}";
        }
        if (this.providers.FirstOrDefault(p => p.Id == id) != null)
        {
            return this.providers.First(p => p.Id == id).ToString();
            
        }

        return this.harvesters.First(h => h.Id == id).ToString();
    }

    public string ShutDown()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {this.totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {this.totalMinedOre}");
        return sb.ToString().Trim();
    }
}
