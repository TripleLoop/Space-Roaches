using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoachCount : MonoBehaviourEx, IHandle<RoachDeathMessage>
{
    public int DeadCount = 0;
    private Text _text;

    private  void Start()
    {
        _text = GetComponent<Text>();
    }

    public void Handle(RoachDeathMessage message)
    {
        DeadCount++;
        _text.text = DeadCount.ToString();
    }
    
    public RoachCount Reset()
    {
        DeadCount = 0;
        _text.text = DeadCount.ToString();
        return this;
    }
}
