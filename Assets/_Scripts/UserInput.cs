using System;
using UnityEngine;
using System.Collections;

public class UserInput : MonoBehaviour
{

    private bool inputEnabled = true;

    void Update()
    {
        if (inputEnabled)
        {
            DetectInput();
        }
    }

    private void DetectInput()
    {
#if UNITY_STANDALONE
        //var position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log(position);
#else
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Began)
            {
                continue;
            }
            // Construct a ray from the current touch coordinates
            var ray = Camera.main.ScreenPointToRay(touch.position);
            if (Physics.Raycast(ray))
            {
                Debug.Log(touch.position.x + touch.position.y);
            }
        }
#endif
    }


}
