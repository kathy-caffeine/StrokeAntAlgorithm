using StrokeAntAlgorithm.Graphs;
using System.Text;

namespace StrokeAntAlgorithm.Ants;

public class Traveller
{
    public Params Params { get; set; }
    public double FinalResult { get; set; }
    public Ant GlobalBestAnt { get; set; }
    public List<Edge> BestRoute { get; set; }
    private Graph Graph { get; set; }
    private Reader Reader { get; set; }

    public Traveller(Params @params, Graph graph, Reader reader)
    {
        Params = @params;
        graph.MinimumPheromone = @params.InitialPheromone;
        Graph = graph;
        BestRoute = new List<Edge>();
        Reader = reader;
    }

    public List<Edge> RunACS()
    {
        var _iterationsAmount = 0;
        Graph.ResetPheromone(Params.InitialPheromone);
        var i = 0;
        while (_iterationsAmount < 10)
        {
            i++;
            List<Ant> antColony = CreateAnts();
            GlobalBestAnt = GlobalBestAnt ?? antColony[0];
            FinalResult = GlobalBestAnt.Distance;
            Ant localBestAnt = BuildTours(antColony);
            if (Params.IterationAmount == 1)
            {
                GlobalBestAnt = localBestAnt;
                FinalResult = localBestAnt.Distance;
                BestRoute = localBestAnt.Path;
            }
            else
            {
                BestRoute = (BestRoute.Count == 0 ? localBestAnt.Path : BestRoute);
                if (localBestAnt.Distance < GlobalBestAnt.Distance)
                {
                    GlobalBestAnt = localBestAnt;
                    FinalResult = localBestAnt.Distance;
                    BestRoute = localBestAnt.Path;

                    Console.WriteLine("Итерация: " + (i).ToString());
                    Console.WriteLine("Дистанция: " + FinalResult);
                    Reader.WriteIterationPath(GlobalBestAnt, i);
                }
                else
                {
                    _iterationsAmount++;
                }
            }
        }
        return BestRoute;
    }

    private List<Ant> CreateAnts()
    {
        List<Ant> antColony = new List<Ant>();
        var rnd = new Random();
        for (int i = 0; i < this.Params.AntAmount; i++)
        {
            Ant ant = new(Graph, Params.Alpha, Params.Beta);
            ant.Init(rnd.Next(Graph.Dimensions-1));
            antColony.Add(ant);
        }
        return antColony;
    }

    private Ant BuildTours(List<Ant> antColony)
    {
        // Гамильтонов путь, а не цикл - поэтому -1
        // каждый шаг проходим 2 ребра, поэтому шаг +2
        for (int i = 0; i < Graph.Dimensions-1; i += 2)
        {
            foreach (Ant ant in antColony)
            {
                ant.Step();
                AddPheromones(ant);
            }
        }

        foreach (var edge in Graph.Edges)
            Graph.SubstractPheromone(edge.Value, (1 - Params.EvaporationRate));

        var crunch = antColony.OrderBy(x => x.Distance).First();
        return crunch;
    }

    private void AddPheromones(Ant ant)
    {
        double deltaR = 1 / ant.Distance;
        foreach (Edge edge in ant.Path)
        {
            double deposit = Params.EvaporationRate * deltaR;
            Graph.AddPheromone(edge, deposit);
        }
    }
}
