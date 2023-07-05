namespace StrokeAntAlgorithm.Ants;

public class Params
{
    public int Alpha { get; set; }
    public int Beta { get; set; }
    public double EvaporationRate { get; set; }
    public double InitialPheromone { get; set; }
    public int AntAmount { get; set; }
    public int IterationAmount { get; set; }

    public Params()
    {
        Alpha = 3;
        Beta = 1;
        EvaporationRate = 0.1;
        AntAmount = 100;
        IterationAmount = 100;
        InitialPheromone = 0.01;
    }
}
