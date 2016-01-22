using UnityEngine;
using System.Collections;

//TODO: should move, try not to create chaos in game
public class Roach : MonoBehaviourEx, IKillable, IWakeable

{
    private ParticleSystem _spawnParticle;
    private bool _hasInitialized;

    public void WakeUp()
    {
        if (!_hasInitialized) Initialize();
        StartCoroutine(Spawn());
    }

    public void Kill()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.RoachSplat));
        Messenger.Publish(new RoachDeathMessage(gameObject));
    }

    private IEnumerator Spawn()
    {
        Messenger.Publish(new SpawnRoachParticleMessage(gameObject));
        yield return new WaitForSeconds(0.5f);
    }

    public Roach Initialize()
    {
        _hasInitialized = true;
        return this;
    }
  
}
