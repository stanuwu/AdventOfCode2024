using System.Diagnostics;

namespace AdventOfCode2024.Framework;

public static class AocSolver
{
    private const string Input = "/home/stan/Documents/AocInput/";
    private static Stopwatch _stopwatch = new();

    private static Span<string> ReadInput(int day)
    {
        return File.ReadAllLines(Input + day + ".txt").AsSpan();
    }
    
    public static void Solve<T>(AocBase<T> aoc)
    {
        Console.WriteLine($"Day {aoc.GetDay()}");
        T input = aoc.ParseData(ReadInput(aoc.GetDay()));
        Console.WriteLine("Part 1");
        _stopwatch.Restart();
        string part1 = aoc.Part1(input);
        _stopwatch.Stop();
        Console.WriteLine($"Solution: {part1} in {Math.Floor(_stopwatch.Elapsed.TotalMilliseconds)}ms {Math.Floor((double) _stopwatch.Elapsed.Microseconds)}µs");
        Console.WriteLine("Part 2");
        _stopwatch.Restart();
        string part2 = aoc.Part2(input);
        _stopwatch.Stop();
        Console.WriteLine($"Solution: {part2} in {Math.Floor(_stopwatch.Elapsed.TotalMilliseconds)}ms {Math.Floor((double) _stopwatch.Elapsed.Microseconds)}µs\n");
    }
}