using AdventOfCode2024.Framework;

namespace AdventOfCode2024.Solutions;

public class Day1 : AocBase<Day1Input>
{
    public override int GetDay()
    {
        return 1;
    }

    public override Day1Input ParseData(Span<string> input)
    {
        int[] left = new int[input.Length];
        int[] right = new int[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            string[] parts = input[i].Split("   ");
            left[i] = int.Parse(parts[0]);
            right[i] = int.Parse(parts[1]);
        }

        return new Day1Input(left, right);
    }

    public override string Part1(Day1Input input)
    {
        Array.Sort(input.Left);
        Array.Sort(input.Right);
        int acc = 0;
        for (int i = 0; i < input.Left.Length; i++)
        {
            acc += Math.Abs(input.Left[i] - input.Right[i]);
        }
        return acc.ToString();
    }

    public override string Part2(Day1Input input)
    {
        Dictionary<int, int> right = new Dictionary<int, int>(input.Right.Length);
        foreach (var i in input.Right)
        {
            right.TryAdd(i, 0);
            right[i]++;
        }

        HashSet<int> left = new HashSet<int>(input.Left.Length);
        foreach (var i in input.Left)
        {
            left.Add(i);
        }

        int final = 0;
        foreach (var i in left)
        {
            right.TryGetValue(i, out int val);
            final += i * val;
        }
        
        return final.ToString();
    }
}

public record Day1Input(int[] Left, int[] Right);