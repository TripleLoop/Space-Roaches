using UnityEngine;
using System.Collections;

public class Smooth_Follow : MonoBehaviour {

    private float _dampTime = 0.05f;
    private Vector3 velocity = Vector3.zero;
    private Transform _target;

    private bool _enable = true;

    public Smooth_Follow Initialize(float dampTime)
    {
        _dampTime = dampTime;
        return this;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_target && _enable)
        {
            //Vector3 point = camera.WorldToViewportPoint(_target.position);
            var delta = _target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, transform.position.z)); //(new Vector3(0.5, 0.5, point.z));
            var destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, 15), new Vector3(destination.x, destination.y, 15), ref velocity, _dampTime);
        }

    }

    public Smooth_Follow SetCameraTarget(GameObject tempTarget)
    {
        _target = tempTarget.transform;
        return this;
    }

    public Smooth_Follow Enable(bool tempEnable)
    {
        _enable = tempEnable;
        return this;
    }
}
