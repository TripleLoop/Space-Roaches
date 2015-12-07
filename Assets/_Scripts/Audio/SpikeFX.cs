using UnityEngine;
using System.Collections;

public class SpikeFX : MonoBehaviour
{

    private AudioSource _source;

    void OnCollisionEnter2D(Collision2D otherCollision)
    {
        if (otherCollision.gameObject.layer == SRLayers.Obstacle)
        {
            _source.Play();
        }
    }

    // Use this for initialization
    void Start ()
    {
        _source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
