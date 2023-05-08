using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrokeAntAlgorithm.Graphs;
public class Stroke
{
    public Point2D Start { get; }
    public Point2D End { get; }
    public double BrushWidth { get; }

    public Stroke(Point2D start, Point2D end, double brushWidth)
    {
        Start = start;
        End = end;
        BrushWidth = brushWidth;
    }
}