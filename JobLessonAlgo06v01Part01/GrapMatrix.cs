//Модифицируйте DFS и BFS из предыдущего урока, но уже для графа, также с выводом каждого шага



public static class GrapMatrix
{
    private class NodesWithLinks
    {
        public int Count { get; set; } = 1;
        public int Value { get; set; }
        public NodesWithLinks LastNode { get; set; }

        public NodesWithLinks(int Value)
        { this.Value = Value; }

        public NodesWithLinks(int Value, NodesWithLinks LastNode) : this(Value)
        {
            this.LastNode = LastNode;
            Count = LastNode.Count + 1;
        }

        public bool Contains(int Value)
        {
            return this.Value == Value ? true : (LastNode?.Contains(Value) ?? false);
        }

        public static int[] GetArray(NodesWithLinks nodes)
        {
            int[] result = new int[nodes?.Count ?? 0];

            NodesWithLinks node;
            int i;

            for (node = nodes, i = 1; node != null; node = node.LastNode, i++)
                result[^i] = node.Value;

            return result;
        }
    }

    public static int[] FastWay(int[,] matrixWeights, int start, int end)
    {
        (NodesWithLinks way, int len) resultWay = (null, int.MaxValue);

        Queue<(NodesWithLinks way, int len)> wayDict = new Queue<(NodesWithLinks way, int len)>();

        wayDict.Enqueue((new NodesWithLinks(start), 0));

        while (wayDict.Count > 0)
        {
            (NodesWithLinks way, int len) topNode = wayDict.Dequeue();

            if (topNode.way.Value == end)
            {
                if (topNode.len < resultWay.len)
                    resultWay = topNode;

                continue;
            }

            for (int i = 0; i < matrixWeights.GetLength(0); i++)
                if (!topNode.way.Contains(i) && matrixWeights[topNode.way.Value, i] != int.MaxValue)
                {
                    wayDict.Enqueue((new NodesWithLinks(i, topNode.way), topNode.len + matrixWeights[topNode.way.Value, i]));
                }
        }

        return NodesWithLinks.GetArray(resultWay.way);

    }

    public static string BFS(int[,] matrix, int start)
    {
        HashSet<int> beforeWave = new HashSet<int>();
        Queue<int> currentWave = new Queue<int>();
        beforeWave.Add(start);
        currentWave.Enqueue(start);

        while (currentWave.Count > 0)
            for (int i = 0, currentVertex = currentWave.Dequeue(); i < matrix.GetLength(0); i++)
                if (matrix[currentVertex, i] != int.MaxValue && beforeWave.Add(i))
                    currentWave.Enqueue(i);

        return new string(beforeWave.Select(el => (char)(1040 + el)).ToArray());
    }

    public static string DFS(int[,] matrix, int start)
    {
        HashSet<int> hashSetWave = new HashSet<int>();
        Stack<int> stackWave = new Stack<int>();
        hashSetWave.Add(start);
        stackWave.Push(start);
        List<int> result = new List<int>();

        while (stackWave.Count > 0)
        {
            result.Add(stackWave.Peek());
            for (int i = 0, currentVertex = stackWave.Pop(); i < matrix.GetLength(0); i++)
                if (matrix[currentVertex, i] != int.MaxValue && hashSetWave.Add(i))
                    stackWave.Push(i);
        }

        return new string(result.Select(el => (char)(1040 + el)).ToArray());
    }

}