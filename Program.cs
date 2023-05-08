using StrokeAntAlgorithm.Ants;
using StrokeAntAlgorithm.Graphs;
using System.Diagnostics;
using System.Text;

var strokes = new List<Stroke>();

/*strokes.Add(new Stroke(new Point2D(35, 48),
new Point2D(43, 53),
4));
strokes.Add(new Stroke(new Point2D(43, 53),
new Point2D(44, 61),
4));
strokes.Add(new Stroke(new Point2D(47, 58),
new Point2D(51, 48),
4));
strokes.Add(new Stroke(new Point2D(40, 50),
new Point2D(39, 43),
4));
strokes.Add(new Stroke(new Point2D(39, 43),
new Point2D(36, 28),
4));
strokes.Add(new Stroke(new Point2D(34, 24),
new Point2D(34, 25),
4));
strokes.Add(new Stroke(new Point2D(39, 21),
new Point2D(39, 22),
4));
strokes.Add(new Stroke(new Point2D(39, 22),
new Point2D(41, 29),
4));
strokes.Add(new Stroke(new Point2D(43, 20),
new Point2D(42, 14),
4));
strokes.Add(new Stroke(new Point2D(42, 14),
new Point2D(38, 4),
4));
strokes.Add(new Stroke(new Point2D(37, 18),
new Point2D(36, 26),
4));
strokes.Add(new Stroke(new Point2D(30, 39),
new Point2D(25, 46),
4));
strokes.Add(new Stroke(new Point2D(38, 47),
new Point2D(37, 42),
4));
strokes.Add(new Stroke(new Point2D(37, 42),
new Point2D(33, 27),
4));
strokes.Add(new Stroke(new Point2D(23, 18),
new Point2D(38, 20),
4));
strokes.Add(new Stroke(new Point2D(26, 14),
new Point2D(35, 9),
4));
strokes.Add(new Stroke(new Point2D(35, 9),
new Point2D(37, 8),
4));
strokes.Add(new Stroke(new Point2D(23, 13),
new Point2D(37, 18),
4));
strokes.Add(new Stroke(new Point2D(24, 17),
new Point2D(37, 15),
4));
strokes.Add(new Stroke(new Point2D(21, 10),
new Point2D(27, 18),
4));
strokes.Add(new Stroke(new Point2D(27, 18),
new Point2D(38, 11),
4));
strokes.Add(new Stroke(new Point2D(18, 2),
new Point2D(30, 9),
4));
strokes.Add(new Stroke(new Point2D(66, 25),
new Point2D(63, 28),
4));
strokes.Add(new Stroke(new Point2D(40, 55),
new Point2D(46, 54),
4));
strokes.Add(new Stroke(new Point2D(38, 56),
new Point2D(52, 62),
4));
strokes.Add(new Stroke(new Point2D(95, 82),
new Point2D(94, 84),
4));
strokes.Add(new Stroke(new Point2D(94, 84),
new Point2D(97, 84),
4));
strokes.Add(new Stroke(new Point2D(97, 84),
new Point2D(96, 86),
4));
strokes.Add(new Stroke(new Point2D(96, 86),
new Point2D(96, 90),
4));
strokes.Add(new Stroke(new Point2D(96, 90),
new Point2D(96, 92),
4));
strokes.Add(new Stroke(new Point2D(35, 45),
new Point2D(35, 44),
4));*/

/*strokes.Add(new Stroke(new Point2D(82, 67),
new Point2D(88, 81),
4));
strokes.Add(new Stroke(new Point2D(88, 81),
new Point2D(87, 81),
4));
strokes.Add(new Stroke(new Point2D(87, 81),
new Point2D(88, 83),
4));
strokes.Add(new Stroke(new Point2D(88, 83),
new Point2D(91, 89),
4));
strokes.Add(new Stroke(new Point2D(91, 89),
new Point2D(93, 86),
4));
strokes.Add(new Stroke(new Point2D(93, 86),
new Point2D(94, 92),
4));
strokes.Add(new Stroke(new Point2D(100, 93),
new Point2D(99, 97),
4));
strokes.Add(new Stroke(new Point2D(99, 88),
new Point2D(98, 94),
4));
strokes.Add(new Stroke(new Point2D(97, 86),
new Point2D(96, 94),
4));
strokes.Add(new Stroke(new Point2D(92, 83),
new Point2D(92, 84),
4));
strokes.Add(new Stroke(new Point2D(92, 84),
new Point2D(92, 80),
4));
strokes.Add(new Stroke(new Point2D(92, 80),
new Point2D(89, 85),
4));
strokes.Add(new Stroke(new Point2D(84, 73),
new Point2D(83, 77),
4));
strokes.Add(new Stroke(new Point2D(87, 71),
new Point2D(74, 79),
4));
strokes.Add(new Stroke(new Point2D(84, 67),
new Point2D(86, 82),
4));
strokes.Add(new Stroke(new Point2D(82, 65),
new Point2D(92, 76),
4));
strokes.Add(new Stroke(new Point2D(79, 61),
new Point2D(85, 65),
4));
strokes.Add(new Stroke(new Point2D(85, 65),
new Point2D(91, 79),
4));
strokes.Add(new Stroke(new Point2D(75, 55),
new Point2D(79, 59),
4));
strokes.Add(new Stroke(new Point2D(79, 59),
new Point2D(81, 60),
4));
strokes.Add(new Stroke(new Point2D(79, 52),
new Point2D(76, 40),
4));
strokes.Add(new Stroke(new Point2D(69, 48),
new Point2D(70, 50),
4));
strokes.Add(new Stroke(new Point2D(67, 28),
new Point2D(66, 31),
4));
strokes.Add(new Stroke(new Point2D(66, 31),
new Point2D(69, 46),
4));
strokes.Add(new Stroke(new Point2D(41, 23),
new Point2D(41, 22),
4));
strokes.Add(new Stroke(new Point2D(41, 22),
new Point2D(41, 18),
4));
strokes.Add(new Stroke(new Point2D(41, 18),
new Point2D(34, 6),
4));
strokes.Add(new Stroke(new Point2D(42, 16),
new Point2D(36, 2),
4));
strokes.Add(new Stroke(new Point2D(16, 3),
new Point2D(26, 11),
4));
strokes.Add(new Stroke(new Point2D(18, 15),
new Point2D(21, 25),
4));
strokes.Add(new Stroke(new Point2D(21, 25),
new Point2D(30, 37),
4));
strokes.Add(new Stroke(new Point2D(30, 37),
new Point2D(28, 39),
4));
strokes.Add(new Stroke(new Point2D(28, 39),
new Point2D(27, 47),
4));
strokes.Add(new Stroke(new Point2D(27, 47),
new Point2D(38, 57),
4));
strokes.Add(new Stroke(new Point2D(40, 24),
new Point2D(46, 22),
4));
strokes.Add(new Stroke(new Point2D(16, 14),
new Point2D(19, 27),
4));
strokes.Add(new Stroke(new Point2D(16, 11),
new Point2D(16, 12),
4));
strokes.Add(new Stroke(new Point2D(16, 5),
new Point2D(19, 9),
4));
strokes.Add(new Stroke(new Point2D(15, 2),
new Point2D(26, 9),
4));
strokes.Add(new Stroke(new Point2D(1, 12),
new Point2D(1, 0),
4));
strokes.Add(new Stroke(new Point2D(15, 0),
new Point2D(16, 0),
4));*/

/*var edges = new List<Edge>();
edges.Add(new Edge(0, 1, 10));
edges.Add(new Edge(1, 2, 11));
edges.Add(new Edge(2, 3, 12));
edges.Add(new Edge(0, 2, 13));
edges.Add(new Edge(0, 3, 14));
edges.Add(new Edge(1, 3, 15));*/


var rnd = new Random();
for (int i = 0; i < 10; i++)
{
    strokes.Add(new Stroke(
        new Point2D(
            (uint)rnd.Next(100), (uint)rnd.Next(100)),
        new Point2D(
            (uint)rnd.Next(100), (uint)rnd.Next(100)),
        1.0));
}

var d = strokes.Count * 2 - 1;

var _params = new Params();

var read = new Reader(strokes);

var graph = new Graph(d, read.edges);

//var sb = new StringBuilder();

Console.WriteLine("Начальная длина пути: " + read.CountStartDistance());

//sb.AppendLine("Начальная длина пути: " + read.CountStartDistance());

/*for(int j = 0; j<5; j++)
{
    var sw = new Stopwatch();
    sw.Start();
    var traveller = new Traveller(_params, graph);
    traveller.RunACS();
    sw.Stop();
    var res = traveller.BestRoute;
    //var distance = traveller.FinalResult;

    var countedDistance = read.CountStartDistance(res);

    Console.WriteLine("Итерация: " + j);
    Console.WriteLine("Время: " + sw.Elapsed);
    Console.WriteLine("Расстояние: " + countedDistance);
    *//*sb.AppendLine("Итерация: " + j);
    sb.AppendLine("Время: " + sw.Elapsed);
    sb.AppendLine("Расстояние: " + distance);*//*

    //sb.AppendLine(sw.Elapsed + " " + countedDistance);
    _params.IterationAmount += 1;
}*/

//Console.WriteLine(sb.ToString());

var traveller = new Traveller(_params, graph);
traveller.RunACS();
var res = traveller.BestRoute;
//var distance = traveller.FinalResult;

var countedDistance = read.CountStartDistance(res);

//Console.WriteLine("Итерация: " + j);
//Console.WriteLine("Время: " + sw.Elapsed);
Console.WriteLine("Расстояние: " + countedDistance);
/*sb.AppendLine("Итерация: " + j);
sb.AppendLine("Время: " + sw.Elapsed);
sb.AppendLine("Расстояние: " + distance);*/

//sb.AppendLine(sw.Elapsed + " " + countedDistance);
_params.IterationAmount += 1;

/*var swr = new StreamWriter("1.txt");
swr.WriteLine(sb.ToString());
swr.Close();*/