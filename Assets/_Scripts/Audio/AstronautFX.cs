using UnityEngine;
using System.Collections;

public class AstronautFX : MonoBehaviour {

    private AudioSource _source;

    [SerializeField]
    private AudioClip _wallHit;
    [SerializeField]
    private AudioClip[] _hit;

    private Rigidbody2D _rigidbody2D;

    private void OnCollisionEnter2D(Collision2D otherCollision)
    {
        if (otherCollision.gameObject.layer == SRLayers.Obstacle)
        {
            _source.clip = _wallHit;
        }
        if (otherCollision.gameObject.layer == SRLayers.Enemy)
        {
            HitEnemy();
        }
        _source.Play();
    }

    private AstronautFX HitEnemy()
    {
        //Debug.Log(_rigidbody2D.velocity.magnitude);
        if (_rigidbody2D.velocity.magnitude <= 1)
        {
            _source.clip = _hit[0];
            return this;
        }
        if (_rigidbody2D.velocity.magnitude <= 2)
        {
            _source.clip = _hit[1];
            return this;
        }
        if (_rigidbody2D.velocity.magnitude <= 3)
        {
            _source.clip = _hit[2];
            return this;
        }
        return this;
    }

    // Use this for initialization
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
