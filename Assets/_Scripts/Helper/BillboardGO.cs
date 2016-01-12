using UnityEngine;
using System.Collections;

public class BillboardGO : MonoBehaviour
{

    private Transform cameraTransform;
    private Transform myTransform;

    void Awake()
    {
        myTransform = transform;
        cameraTransform = GameObject.Find("mainCamera").transform;
    }

    void Update()
    {
        Vector3 v = cameraTransform.position - myTransform.position;
        v.x = v.z = 0.0f;
        myTransform.LookAt(cameraTransform.position - v);
    }

}