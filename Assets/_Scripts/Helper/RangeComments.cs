public class RangeComments
{
    public string[] Comments { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    public RangeComments (string[] comments, int min, int max)
    {
        Comments = comments;
        Min = min;
        Max = max;
    }
}

