﻿using UnityEngine;
using System.Collections;

public class Smooth_Follow : MonoBehaviour {

    public float dampTime = 0.05f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    // Update is called once per frame
    void LateUpdate()
    {
        if (target)
        {
            //Vector3 point = camera.WorldToViewportPoint(target.position);
            var delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, transform.position.z)); //(new Vector3(0.5, 0.5, point.z));
            var destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y, 15), new Vector3(destination.x, destination.y, 15), ref velocity, dampTime);
        }

    }

    IEnumerator FastRelocationPhase()
    {
        dampTime = 20000;
        yield return null;
        yield return null;
        yield return null;
        dampTime = 0.05f;
    }
}
