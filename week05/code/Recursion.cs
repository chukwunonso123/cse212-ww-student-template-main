using System.Collections.Generic;
using System.Diagnostics;

public static class Recursion
{
    /// <summary>
    /// Problem 1: Recursive Squares Sum
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0;

        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: Permutations Choose
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// Problem 3: Climbing Stairs (Memoized)
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (s < 0)
            return 0;
        if (s == 0)
            return 1;

        if (remember == null)
            remember = new Dictionary<int, decimal>();

        if (remember.ContainsKey(s))
            return remember[s];

        decimal ways = CountWaysToClimb(s - 1, remember)
                     + CountWaysToClimb(s - 2, remember)
                     + CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: Wildcard Binary Patterns
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int index = pattern.IndexOf('*');
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        string withZero = pattern.Substring(0, index) + '0' + pattern.Substring(index + 1);
        string withOne = pattern.Substring(0, index) + '1' + pattern.Substring(index + 1);

        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// Problem 5: Maze Solver
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<(int, int)>? currPath = null)
    {
        if (currPath == null)
        {
            currPath = new List<(int, int)>();
        }

        if (!maze.IsValidMove(currPath, x, y))
            return;

        currPath.Add((x, y));

        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1);
            return;
        }

        // Explore all four directions
        SolveMaze(results, maze, x + 1, y, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x - 1, y, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x, y + 1, new List<(int, int)>(currPath));
        SolveMaze(results, maze, x, y - 1, new List<(int, int)>(currPath));

        // Backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}
