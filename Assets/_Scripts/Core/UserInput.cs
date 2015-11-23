using System;
using UnityEngine;
using System.Collections;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

public class UserInput : MonoBehaviourEx
{

    private bool _inputEnabled = false;
    private Camera _mainCamera;


    public UserInput EnableInput()
    {
        this._inputEnabled = true;
        return this;
    }

    public UserInput DisableInput()
    {
        this._inputEnabled = false;
        return this;
    }

    public UserInput SetCamera(Camera tempCamera)
    {
        this._mainCamera = tempCamera;
        return this;
    }

    void Update()
    {
        if (!_inputEnabled)
        {
            return;
        }

#if UNITY_STANDALONE

        if (Input.GetMouseButtonDown(0))
        {
            var position = DetectInput();
            Messenger.Publish(new UserInputMessage(position));
        }

#elif UNITY_ANDROID

        if (Input.touchCount > 0)
        {
            if (!IsTouchPhaseBegan())
            {
                return;
            }
            var position = DetectInput();
            Messenger.Publish(new UserInputMessage(position));
        }

#endif

    }

    private Vector2 DetectInput()
    {
        if (!_mainCamera)
        {
            Debug.Log("Prevented crash in userInput");
            return new Vector2();
        }

#if UNITY_STANDALONE

        var position = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        //Debug.Log("input detected ===>" + position);
        return position;

#else
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Began)
            {
                continue;
            }
            // Construct a ray from the current touch coordinates
            //var ray = _mainCamera.ScreenPointToRay(touch.position);
            //if (Physics.Raycast(ray))
            //{   
            //    Debug.Log(touch.position.x + touch.position.y);
            //}
            var position = _mainCamera.ScreenToWorldPoint(touch.position);
            Debug.Log("touch input detected ===>" + position);
            return position;
        }
        return new Vector2();
#endif

    }

#if UNITY_ANDROID
    private bool IsTouchPhaseBegan()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                return true;
            }
        }
        return false;
    }
#endif

}
