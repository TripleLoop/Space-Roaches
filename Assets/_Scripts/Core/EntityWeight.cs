using UnityEngine;
using System.Collections;

public class EntityWeight
{
    public string Name { get; set; }
    public int Weight { get; set; }

    public EntityWeight(string name, int weight)
    {
        Weight = weight;
        Name = name;
    }
}
