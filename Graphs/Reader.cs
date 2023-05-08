using System.ComponentModel.DataAnnotations;

namespace StrokeAntAlgorithm.Graphs;

public class Reader
{
    private List<Stroke> strokes;
    private List<Point2D> points;
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
}
