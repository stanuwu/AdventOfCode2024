namespace AdventOfCode2024.Framework;

public abstract class AocBase<T>
{
    public abstract int GetDay();
    public abstract T ParseData(Span<string> input);

    public virtual string Part1(T input)
    {
        return "Not Implemented";
    }
    
    public virtual string Part2(T input)
    {
        return "Not Implemented";
    }
}