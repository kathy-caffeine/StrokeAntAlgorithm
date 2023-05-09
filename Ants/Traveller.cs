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
        Graph.ResetPheromone(Params.InitialPheromone);
        for (int i = 0; i < Params.IterationAmount; i++)
        {
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
                    /*var s_sb = new StringBuilder();
                    var t_sb = new StringBuilder();
                    var weights = new StringBuilder();
                    s_sb.Append("[");
                    t_sb.Append("[");
                    weights.Append("[");
                    foreach(var p in BestRoute)
                    {
                        s_sb.Append((p.StartVertex+1).ToString() + ", ");
                        t_sb.Append((p.FinishVertex+1).ToString() + ", ");
                        weights.Append(p.Pheromone + ", ");
                    }
                    s_sb.Append("]");
                    t_sb.Append(']');
                    weights.Append("]");
                    var swr = new StreamWriter(i.ToString() + ".txt");
                    swr.WriteLine(s_sb.ToString());
                    swr.WriteLine(t_sb.ToString());
                    swr.WriteLine(weights.ToString());
                    swr.Close();*/

                    Reader.WriteIterationPath(localBestAnt, i);
                }
            }

        }
        return BestRoute;
    }

    public List<Ant> CreateAnts()
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

    public Ant BuildTours(List<Ant> antColony)
    {
        // Гамильтонов путь, а не цикл - поэтому -1
        // каждый шаг проходим 2 ребра, поэтому шаг +2
        for (int i = 0; i < Graph.Dimensions-1; i += 2)
        {
            foreach (Ant ant in antColony)
            {
                ant.Step();
                AddPheromones(ant);
                /*Console.Write("Феромон на минимальном ребре: ");
                Console.WriteLine(Graph.Edges[Graph.HashFunction(nums[0], nums[1])].Pheromone);
                Console.Write("Феромон на максимальном ребре: ");
                Console.WriteLine(Graph.Edges[Graph.HashFunction(nums[2], nums[3])].Pheromone);*/
            }
        }

        foreach (var edge in Graph.Edges)
            Graph.SubstractPheromone(edge.Value, (1 - Params.EvaporationRate));

        var crunch = antColony.OrderBy(x => x.Distance).FirstOrDefault();
        return crunch!;
    }

    public void AddPheromones(Ant ant)
    {
        double deltaR = 1 / ant.Distance;
        foreach (Edge edge in ant.Path)
        {
            double deposit = Params.EvaporationRate * deltaR;
            Graph.AddPheromone(edge, deposit);
        }

        /*var g = ant.Path.OrderBy(x => x.Length).ToList();
        Console.WriteLine("Феромон на минимальном ребре: " + g[0].Pheromone);
        Console.WriteLine("Феромон на максимальном ребре: " + g[g.Count - 1].Pheromone);*/
    }
}
