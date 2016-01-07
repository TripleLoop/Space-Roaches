using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class SelectEndScreenText
{
    public String CommentByScore(int score, List<RangeComments> rangesComments)
    {
        foreach (var range in rangesComments)
        {
            if (range.Min <= score && score <= range.Max)
            {
                return range.Comments[Random.Range(0, range.Comments.Length)];
            }
        }
        return null;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
