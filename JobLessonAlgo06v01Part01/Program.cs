//Модифицируйте DFS и BFS из предыдущего урока, но уже для графа, также с выводом каждого шага

Console.WriteLine("Модифицировать DFS и BFS из предыдущего урока, но уже для графа, " +
    "также с выводом каждого шага");

int[,] graphMatrix = new int[,]
{
         // А  Б  В  Г  Д  Е
   /*А*/  { 0, 20, 5, 0, 7, 0 },
   /*Б*/  { 0, 0, 0, 0, 3, 30 },
   /*В*/  { 10, 0, 0, 1, 0, 0 },
   /*Г*/  { 0, 0, 50, 0, 0, 6 },
   /*Д*/  { 0, 1, 0, 0, 60, 0 },
   /*Е*/  { 7, 0, 0, 40, 0, 0 },
};

string[] graph = new string[] { "А",  "Б",  "В",  "Г",  "Д",  "Е" };
Console.WriteLine(string.Join("->", GrapMatrix.FastWay(graphMatrix, 3, 2).Select(d => graph[d])));
Console.WriteLine(GrapMatrix.BFS(graphMatrix, 3));
Console.WriteLine(GrapMatrix.DFS(graphMatrix, 3));
