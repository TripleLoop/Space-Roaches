using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoachCount : MonoBehaviourEx, IHandle<RoachDeathMessage>
{
    public int DeadCount = 0;

    public void Handle(RoachDeathMessage message)
    {
        //Debug.Log("HELO");
        DeadCount++;
        GetComponent<Text>().text = ""+DeadCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Use this for initialization
    void Start()
    {

    }
}
