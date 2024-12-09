using System.Text.RegularExpressions;
using AdventOfCode2024.Framework;

namespace AdventOfCode2024.Solutions;

public class Day4 : AocBase<string[]>
{
    private Regex[]? _patterns;
    private Regex[]? _patterns2;
    
    public override int GetDay()
    {
        return 4;
    }

    public override string[] ParseData(Span<string> input)
    {
        int width = input[0].Length + 1;

        _patterns = new[]
        {
            new Regex("XMAS"),
            new Regex("SAMX"),
            new Regex($"X.{{{width - 1}}}M.{{{width - 1}}}A.{{{width - 1}}}S"),
            new Regex($"S.{{{width - 1}}}A.{{{width - 1}}}M.{{{width - 1}}}X"),
            new Regex($"X[A-Z]{{3}}.{{{width - 3}}}M.{{{width}}}A.{{{width}}}S"),
            new Regex($"S[A-Z]{{3}}.{{{width - 3}}}A.{{{width}}}M.{{{width}}}X"),
            new Regex($"[A-Z]{{3}}X.{{{width - 2}}}M.{{{width - 2}}}A.{{{width - 2}}}S"),
            new Regex($"[A-Z]{{3}}S.{{{width - 2}}}A.{{{width - 2}}}M.{{{width - 2}}}X"),
        };
        
        _patterns2 = new[]
        {
            new Regex($"M[A-Z]M.{{{width - 2}}}A.{{{width - 2}}}S[A-Z]S"),
            new Regex($"M[A-Z]S.{{{width - 2}}}A.{{{width - 2}}}M[A-Z]S"),
            new Regex($"S[A-Z]S.{{{width - 2}}}A.{{{width - 2}}}M[A-Z]M"),
            new Regex($"S[A-Z]M.{{{width - 2}}}A.{{{width - 2}}}S[A-Z]M"),
        };
        
        return input.ToArray();
    }

    public override string Part1(string[] input)
    {
        string joined = string.Join(';', input);
        int count = 0;

        for (var i = 0; i < _patterns!.Length; i++)
        {
            // only need overlap for these
            if (i > 1)
            {
                var pattern = _patterns[i];
                Match match = pattern.Match(joined);
                while (match.Success)
                {
                    count++;
                    match = pattern.Match(joined, match.Index + 1);
                }
            }
            else
            {
                count += _patterns[i].Matches(joined).Count;
            }
        }

        return count.ToString();
    }

    public override string Part2(string[] input)
    {
        string joined = string.Join(';', input);
        int count = 0;

        for (var i = 0; i < _patterns2!.Length; i++)
        {
            var pattern = _patterns2[i];
            Match match = pattern.Match(joined);
            while (match.Success)
            {
                count++;
                match = pattern.Match(joined, match.Index + 1);
            }
        }

        return count.ToString();
    }
}