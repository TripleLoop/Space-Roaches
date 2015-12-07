using UnityEngine;
using System.Collections;
using TypeSafe;
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
	    _scene = Application.loadedLevelName;
	    _source = GetComponent<AudioSource>();

        if (_scene == SRScenes.MainGame.name)
        {
            _source.clip = _music[1];
        }
        _source.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
