﻿using UnityEngine;
using LocalConfig = Config.Camera.Game;

public class Smooth_Follow : MonoBehaviour {

    private float _dampTime;
    private Vector3 velocity = Vector3.zero;
    private Transform _target;

    private bool _enable = true;

    private Vector3 _cameraPosition;

    private void Start()
    {
        _dampTime = LocalConfig.DampTime;
    }

    public Vector3 SendCameraPosition()
    {
        return _cameraPosition;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (_target && _enable)
        {
            //Vector3 point = camera.WorldToViewportPoint(_target.position);
            var delta = _target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, transform.position.z)); //(new Vector3(0.5, 0.5, point.z));
            var destination = transform.position + delta;
            _cameraPosition = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, LocalConfig.ZPosition), new Vector3(destination.x, destination.y, LocalConfig.ZPosition), ref velocity, _dampTime);
            transform.position = _cameraPosition;
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
