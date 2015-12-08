using UnityEngine;
using System.Collections;
using TypeSafe;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Music : MonoBehaviour
{
    private string _scene;
    private AudioSource _source;
    [SerializeField]
    private AudioClip[] _music;

	// Use this for initialization
	void Start ()
	{
	    _source = GetComponent<AudioSource>();
        _source.clip = _music[1];
        _source.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
