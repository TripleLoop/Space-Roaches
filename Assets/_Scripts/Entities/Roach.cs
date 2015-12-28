using UnityEngine;
using System.Collections;

public class Roach : MonoBehaviourEx
{
    private ParticleSystem _spawnParticle;

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag(SRTags.Player))
        {
            Messenger.Publish(new RoachDeathMessage(gameObject));
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.MediumHit));
            return;
        }
    }

    void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Messenger.Publish(new SpawnRoachParticleMessage(gameObject));
        yield return new WaitForSeconds(0.5f);
    }
}
