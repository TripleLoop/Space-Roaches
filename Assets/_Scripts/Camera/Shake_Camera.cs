using UnityEngine;
using System.Collections;
using LocalConfig = Config.Camera.Game;

public class Shake_Camera : MonoBehaviourEx, IHandle<RoachDeathMessage>, IHandle<AstronautDeathMessage>, IHandle<SpikeBallDeathMessage>
{

    private float _duration = LocalConfig.ShakeDuration;
    private float _magnitude = LocalConfig.ShakeMagnitude;

    private Vector3 _cameraPosition;

    private Smooth_Follow _smoothFollow;
    
    // Use this for initialization
    void Start()
    {
        _smoothFollow = GetComponent<Smooth_Follow>();
    }

    public void Handle(RoachDeathMessage message)
    {
        StartCoroutine(Shake(1f));
    }

    public void Handle(SpikeBallDeathMessage message)
    {
        StartCoroutine(Shake(1.5f));
    }

    public void Handle(AstronautDeathMessage message)
    {
        StartCoroutine(Shake(2f));
    }

    public IEnumerator Shake(float scaleMagnitude)
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
            x *= _magnitude * damper * scaleMagnitude;
            y *= _magnitude * damper * scaleMagnitude;

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
