using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    private RoachCount _roachCount;
    private DashMeter _dashMeter;
    private EndScreen _endScreen;

    private void Start()
    {
        _roachCount = GetComponentInChildren<RoachCount>();
        _dashMeter = GetComponentInChildren<DashMeter>();
        _endScreen = GetComponentInChildren<EndScreen>();
        _endScreen.Initialize(_roachCount);
    }

    public CanvasManager Reset()
    {
        _roachCount.Reset();
        _dashMeter.Reset();
        _endScreen.Reset();
        return this;
    }
}
