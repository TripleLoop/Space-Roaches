using UnityEngine;

public class SpikeBallDeathMessage
{
    public GameObject SpikeBall { get; set; }

    public SpikeBallDeathMessage(GameObject spikeBall)
    {
        this.SpikeBall = spikeBall;
    }
}
