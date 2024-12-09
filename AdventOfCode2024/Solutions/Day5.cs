using AdventOfCode2024.Framework;

namespace AdventOfCode2024.Solutions;

public class Day5 : AocBase<Day5Input>
{
    public override int GetDay()
    {
        return 5;
    }

    public override Day5Input ParseData(Span<string> input)
    {
        Dictionary<int, HashSet<int>> rules = new();
        List<HashSet<int>> pages = new List<HashSet<int>>();
        bool passed = false;
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == "")
            {
                passed = true;
                continue;
            }

            if (!passed)
            {
                string[] parts = input[i].Split('|');
                int part0 = int.Parse(parts[0]);
                int part1 = int.Parse(parts[1]);
                if (!rules.ContainsKey(part1))
                {
                    rules[part1] = new HashSet<int>() {part0};
                }
                else
                {
                    rules[part1].Add(part0);
                }
            }
            else
            {
                pages.Add([..input[i].Split(',').Select(int.Parse).ToArray()]);
            }
        }

        return new Day5Input(rules, pages.ToArray());
    }

    public override string Part1(Day5Input input)
    {
        int count = 0;
        foreach (HashSet<int> page in input.Pages)
        {
            bool valid = true;
            HashSet<int> happened = new();
            foreach (int num in page)
            {
                if (!input.Rules.ContainsKey(num)) continue;
                foreach (var i in input.Rules[num])
                {
                    if (page.Contains(i) && !happened.Contains(i))
                    {
                        valid = false;
                        break;
                    }
                }

                if (!valid) break;

                happened.Add(num);
            }

            if (valid)
            {
                count += page.ElementAt(page.Count / 2);
            }
        }

        return count.ToString();
    }

    public override string Part2(Day5Input input)
    {
        int count = 0;
        foreach (HashSet<int> page in input.Pages)
        {
            bool valid = true;
            HashSet<int> happened = new();
            foreach (int num in page)
            {
                if (!input.Rules.ContainsKey(num)) continue;
                foreach (var i in input.Rules[num])
                {
                    if (page.Contains(i) && !happened.Contains(i))
                    {
                        valid = false;
                        break;
                    }
                }

                if (!valid) break;

                happened.Add(num);
            }

            if (!valid)
            {
                count += page.OrderBy(i =>
                {
                    if (!input.Rules.ContainsKey(i)) return 0;
                    int c = 0;
                    foreach (var l in input.Rules[i])
                    {
                        if (page.Contains(l)) c++;
                    }

                    return c;
                }).ElementAt(page.Count / 2);
            }
        }

        return count.ToString();
    }
}

public record Day5Input(Dictionary<int, HashSet<int>> Rules, HashSet<int>[] Pages);