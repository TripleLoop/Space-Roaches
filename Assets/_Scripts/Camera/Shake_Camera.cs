using UnityEngine;
using System.Collections;

public class Shake_Camera : MonoBehaviourEx, IHandle<RoachDeathMessage>
{

    private float _duration = 0.5f;
    private float _magnitude = 0.1f;

    private Vector3 _cameraPosition;

    private Smooth_Follow _smoothFollow;
    
    // Use this for initialization
    void Start()
    {
        _smoothFollow = GetComponent<Smooth_Follow>();
    }

    public void Handle(RoachDeathMessage message)
    {
        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {

        float elapsed = 0.0f;

        while (elapsed < _duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / _duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= _magnitude * damper;
            y *= _magnitude * damper;

            _cameraPosition = _smoothFollow.SendCameraPosition();
            gameObject.transform.position = new Vector3(x + _cameraPosition.x, y + _cameraPosition.y, _cameraPosition.z);

            yield return null;
        }

        gameObject.transform.position = new Vector3(_cameraPosition.x, _cameraPosition.y, _cameraPosition.z);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
