using StrokeAntAlgorithm.Ants;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace StrokeAntAlgorithm.Graphs;

public class Reader
{
    private List<Stroke> strokes;
    public List<Point2D> points;
    public List<Edge> edges;

    public Reader(List<Stroke> strokes)
    {
        points = new List<Point2D>();
        edges = new List<Edge>();
        this.strokes = strokes;
        //strokes = strokes.OrderBy(x=>x.Start).ThenBy(x=>x.End).ToList();
        foreach (Stroke stroke in strokes)
        {
            points.Add(stroke.Start);
            points.Add(stroke.End);
        }

        // верхнетреугольная матрица
        // кусочек полной матрицы смежности для графа
        for (int i = 0; i < points.Count; i++)
        {
            for (int j = i+1; j < points.Count; j++)
            {
                var d = CountDistance(points[i], points[j]);
                edges.Add(new Edge(i, j, d));
            }
        }
    }

    private double CountDistance(Point2D start, Point2D finish)
    {
        var d = Math.Sqrt(
            (start.X - finish.X) * (start.X - finish.X) +
            (start.Y - finish.Y) * (start.Y - finish.Y)
            );
        // расстояния 0 не должно быть, потому что это физически одна точка
        // но принадлежащая разным мазкам
        // длину следующего или текущего мазка нужно уменьшить на 1 точку?
        if (d == 0) 
            d = 1e-14;
        return d;
    }

    public double CountStartDistance()
    {
        var res = 0.0;
        for(int i = 1; i< points.Count; i++)
        {
            res += CountDistance(points[i], points[i - 1]);
        }
        return res;
    }

    public double CountStartDistance(List<Edge> e)
    {
        var res = 0.0;
        for (int i = 1; i < e.Count; i++)
        {
            res += e[i].Length;
        }
        return res;
    }

    public void WriteIterationPath(Ant ant, int n)
    {
        var cmp = new StrokesCompiler(ant.Path, strokes);
        var str = cmp.ConvertToStrokes();

        var swr = new StreamWriter("iteration_" + n + ".txt");
        var sb_start_x = new StringBuilder();
        sb_start_x.Append("[");
        var sb_start_y = new StringBuilder();
        sb_start_y.Append("[");
        for(int i = 0; i<str.Count; i++)
        {
            sb_start_x.Append(str[i].Start.X + ", ");
            sb_start_x.Append(str[i].End.X + ", ");
            sb_start_y.Append(str[i].Start.Y + ", ");
            sb_start_y.Append(str[i].End.Y + ", ");
        }

        swr.WriteLine(sb_start_x.ToString());
        swr.WriteLine(sb_start_y.ToString());
        swr.Close();
    }

    public string PrintPath(Ant ant)
    {
        int[] res = new int[ant.Path.Count + 1];
        string path = "";
        if (ant.Path[0].StartVertex == ant.Path[1].StartVertex ||
            ant.Path[0].StartVertex == ant.Path[1].FinishVertex)
        {
            res[0] = ant.Path[0].FinishVertex;
            path += ant.Path[0].FinishVertex + " ";
        }
        else
        {
            res[0] = ant.Path[0].StartVertex;
            path += ant.Path[0].StartVertex + " ";
        }
        for (int i = 1; i < ant.Path.Count + 1; i++)
        {
            res[i] = -1;
        }
        for (int i = 0; i < ant.Path.Count; i++)
        {
            if (Array.IndexOf(res, ant.Path[i].StartVertex) <= -1)
            {
                res[i + 1] = ant.Path[i].StartVertex;
            path += ant.Path[i].StartVertex + " ";
            }
            else if (Array.IndexOf(res, ant.Path[i].FinishVertex) <= -1)
            {
                res[i + 1] = ant.Path[i].FinishVertex;
                path += ant.Path[i].FinishVertex + " ";
            }
        }
        return path;
    }
}
