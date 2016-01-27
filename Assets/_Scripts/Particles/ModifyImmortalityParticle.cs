using System;
using UnityEngine;
using System.Collections;
using LocalConfig = Config.Entities.Astronaut;

public class ModifyImmortalityParticle : MonoBehaviourEx, IHandle<AstronautImmortalityMessage>
{
    private Color _startColor;
    private float _startSize;

    public void Start()
    {
        _startColor = GetComponent<ParticleSystem>().startColor;
        _startSize = GetComponent<ParticleSystem>().startSize;
    }

    private IEnumerator AlertImmortalityEnd()
    {
        yield return new WaitForSeconds(LocalConfig.ImmortalityTime - 3);
        this.GetComponent<ParticleSystem>().startColor = Color.red;
        this.GetComponent<ParticleSystem>().startSize = 3f;

        yield return new WaitForSeconds(2.6f);
        this.GetComponent<ParticleSystem>().startColor = _startColor;
        this.GetComponent<ParticleSystem>().startSize = _startSize;
    }

    public void Handle(AstronautImmortalityMessage message)
    {
        if (!message.Immortal)
            return;

        StartCoroutine(AlertImmortalityEnd());
    }
}
