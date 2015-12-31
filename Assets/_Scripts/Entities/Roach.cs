using UnityEngine;
using System.Collections;

public class Roach : MonoBehaviourEx, IKillable

{
    private ParticleSystem _spawnParticle;

    public void Kill()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.MediumHit));
        Messenger.Publish(new RoachDeathMessage(gameObject));
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        Messenger.Publish(new SpawnRoachParticleMessage(gameObject));
        yield return new WaitForSeconds(0.5f);
    }


}
