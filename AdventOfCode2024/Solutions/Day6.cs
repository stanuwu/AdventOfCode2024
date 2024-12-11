using AdventOfCode2024.Framework;

namespace AdventOfCode2024.Solutions;

public class Day6 : AocBase<int[][]>
{
    public override int GetDay()
    {
        return 6;
    }

    public override int[][] ParseData(Span<string> input)
    {
        int[][] output = new int[input.Length][];
        for (int i = 0; i < input.Length; i++)
        {
            output[i] = input[i].Select(c =>
            {
                switch (c)
                {
                    case '.':
                        return 0;
                    case '#':
                        return 1;
                    case '^':
                        return 2;
                }

                return -1;
            }).ToArray();
        }

        return output;
    }

    public override string Part1(int[][] input)
    {
        return base.Part1(input);
    }
}