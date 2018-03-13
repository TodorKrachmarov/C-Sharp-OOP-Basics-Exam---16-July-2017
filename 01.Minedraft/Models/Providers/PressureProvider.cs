public class PressureProvider : Provider
{
    public PressureProvider(string id, double energyOutput) 
        : base(id, energyOutput + (energyOutput * 50) / 100)
    {
    }
}
