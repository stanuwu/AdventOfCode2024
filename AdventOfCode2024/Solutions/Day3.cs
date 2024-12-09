using System.Text.RegularExpressions;
using AdventOfCode2024.Framework;

namespace AdventOfCode2024.Solutions;

public class Day3 : AocBase<string>
{
    private Regex _pattern1 = new Regex("mul\\(\\d{0,3}\\,\\d{0,3}\\)");
    private Regex _pattern2 = new Regex("(mul\\([0-9]{0,3}\\,[0-9]{0,3}\\))|(don't)|(do)");
    
    public override int GetDay()
    {
        return 3;
    }

    public override string ParseData(Span<string> input)
    {
        return string.Join(' ', input.ToArray());
    }

    public override string Part1(string input)
    {
        int count = 0;
        
        foreach (Match match in _pattern1.Matches(input))
        {
            string[] parts = match.Value.Split(',', '(', ')');
            count += Convert.ToInt32(parts[1]) * Convert.ToInt32(parts[2]);
        }

        return count.ToString();
    }

    public override string Part2(string input)
    {
        int count = 0;
        bool enabled = true;
        
        foreach (Match match in _pattern2.Matches(input))
        {
            switch (match.Value)
            {
                case "do":
                    enabled = true;
                    break;
                
                case "don't":
                    enabled = false;
                    break;
                default:
                    string[] parts = match.Value.Split(',', '(', ')');
                    if (enabled) count += Convert.ToInt32(parts[1]) * Convert.ToInt32(parts[2]);
                    break;
            }
        }

        return count.ToString();
    }
}