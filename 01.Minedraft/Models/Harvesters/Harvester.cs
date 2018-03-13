using System;
using System.Text;

public abstract class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id { get { return this.id; } }

    public double EnergyRequirement
    {
        get { return this.energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException("Harvester is not registered, because of it's EnergyRequirement");
            }
            this.energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return this.oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException("Harvester is not registered, because of it's OreOutput");
            }
            this.oreOutput = value;
        }
    }

    public override string ToString()
    {
        int index = this.GetType().Name.IndexOf("Harvester");
        string type = this.GetType().Name.Substring(0, index);
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{type} Harvester - {this.id}");
        sb.AppendLine($"Ore Output: {this.oreOutput}");
        sb.AppendLine($"Energy Requirement: {this.energyRequirement}");
        return sb.ToString().Trim();
    }
}
