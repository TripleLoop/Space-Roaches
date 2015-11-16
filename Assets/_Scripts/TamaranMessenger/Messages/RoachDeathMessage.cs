using UnityEngine;

public class RoachDeathMessage
{
    public GameObject Roach { get; set; }

    public RoachDeathMessage(GameObject roach)
    {
        this.Roach = roach;
        Debug.Log("DEAD ROACH");
    }
}

