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
        int gx = -1;
        int gy = -1;
        int go = 0;

        int width = input[0].Length;
        int height = input.Length;

        for (int y = 0; y < height; y++)
        for (int x = 0; x < width; x++)
        {
            if (input[y][x] == 2)
            {
                gx = x;
                gy = y;
                input[y][x] = 0;
                break;
            }   
        }

        HashSet<int> visited = new HashSet<int>();
        
        while (true)
        {
            visited.Add(gx + (gy << 10));
            int nextX = gx;
            int nextY = gy;
            switch (go)
            {
                case 0:
                    nextY--;
                    break;
                case 1:
                    nextX++;
                    break;
                case 2:
                    nextY++;
                    break;
                case 3:
                    nextX--;
                    break;
            }

            if (nextX < 0 || nextX >= width || nextY < 0 || nextY >= height)
            {
                break;
            }

            switch (input[nextY][nextX])
            {
                case 0:
                    gx = nextX;
                    gy = nextY;
                    break;
                case 1:
                    go++;
                    if (go > 3) go = 0;
                    break;
            }
        }
        
        return visited.Count.ToString();
    }
}