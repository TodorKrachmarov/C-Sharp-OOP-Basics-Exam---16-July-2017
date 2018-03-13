using System;

public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) 
        : base(id, oreOutput, energyRequirement / sonicFactor)
    {
        this.sonicFactor = sonicFactor;
    }

    //public int SonicFactor
    //{
    //    get { return this.sonicFactor; }
    //    private set
    //    {
    //        if (value <= 0)
    //        {
    //            throw new ArgumentException("Harvester is not registered, because of it's SonicFactor");
    //        }
    //        this.sonicFactor = value;
    //    }
    //}
}
