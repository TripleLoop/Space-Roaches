using System;
using UnityEngine;
using System.Collections;
using LocalConfig = Config.Entities.Astronaut;

public class ModifyImmortalityParticle : MonoBehaviourEx, IHandle<AstronautImmortalityMessage>
{
    private Color _startColor;
    private float _startSize;

    private Color _secondaryStartColor;
    private float _secondaryStartSize;

    private ParticleSystem[] _particles;

    public void Start()
    {
        _particles = GetComponentsInChildren<ParticleSystem>();
        _startColor = _particles[0].startColor;
        _startSize = _particles[0].startSize;

        _secondaryStartColor = _particles[1].startColor;
        _secondaryStartSize = _particles[1].startSize;
    }

    private IEnumerator AlertImmortalityEnd()
    {
        yield return new WaitForSeconds(LocalConfig.ImmortalityTime - 3);
        _particles[0].startColor = Color.red;
        _particles[0].startSize = 3f;
        _particles[1].startColor = Color.red;
        _particles[1].startSize = 3f;
        yield return new WaitForSeconds(2.5f);
        _particles[0].startSize = 0;
        _particles[1].startSize = 0;
        yield return new WaitForSeconds(0.5f);
        _particles[0].startColor = _startColor;
        _particles[0].startSize = _startSize;
        _particles[1].startColor = _secondaryStartColor;
        _particles[1].startSize = _secondaryStartSize;
    }

    public void Handle(AstronautImmortalityMessage message)
    {
        if (!message.Immortal)
            return;

        StartCoroutine(AlertImmortalityEnd());
    }
}
