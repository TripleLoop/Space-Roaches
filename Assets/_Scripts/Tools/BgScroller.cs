using UnityEngine;
using System.Collections;

//TODO: background scroll inside canvas
public class BgScroller : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 0.5f;
  
    void Update()
    {
      Vector2 offset = new Vector2(Time.time*scrollSpeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}