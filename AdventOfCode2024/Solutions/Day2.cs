using AdventOfCode2024.Framework;

namespace AdventOfCode2024.Solutions;

public class Day2 : AocBase<int[][]>
{
    public override int GetDay()
    {
        return 2;
    }

    public override int[][] ParseData(Span<string> input)
    {
        int[][] data = new int[input.Length][];
        for (int i = 0; i < input.Length; i++)
        {
            data[i] = input[i].Split(' ').Select(int.Parse).ToArray();
        }

        return data;
    }

    public override string Part1(int[][] input)
    {
        int counter = 0;
        foreach (var i in input)
        {
            if (IsSafe(i)) counter++;
        }
        
        return counter.ToString();
    }

    public override string Part2(int[][] input)
    {
        int counter = 0;
        foreach (var i in input)
        {
            if (IsSafe(i)) counter++;
            else
            {
                int[] temp = new int[i.Length - 1];
                for (int j = 0; j < i.Length; j++)
                {
                    Array.Copy(i, temp, j);
                    Array.Copy(i, j + 1, temp, j, temp.Length - j);
                    if (IsSafe(temp))
                    {
                        counter++;
                        break;
                    }
                }
            }
        }
        
        return counter.ToString();
    }

    private bool IsSafe(int[] i)
    {
        bool safe = true;
        int lastDiff = 0;
        
        for (int j = 0; j < i.Length - 1; j++)
        {
            int diff = i[j] - i[j + 1];

            if (diff == 0)
            {
                safe = false;
                break;
            }
                
            if (
                (diff < 0 && lastDiff > 0) ||
                (diff > 0 && lastDiff < 0)
            )
            {
                safe = false;
                break;
            }

            if (Math.Abs(diff) > 3)
            {
                safe = false;
                break;
            }
                
            lastDiff = diff;
        }

        return safe;
    }
}