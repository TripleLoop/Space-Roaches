using UnityEngine;
using System.Collections;
using PathologicalGames;

public class SpawnParticles : MonoBehaviourEx, IHandle<RoachDeathMessage>, IHandle<SpikeBallDeathMessage>
{

    private SpawnPool _particlePool; 

	// Use this for initialization
	void Start ()
	{
	    _particlePool = GetComponent<SpawnPool>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Handle(RoachDeathMessage message)
    {
        SpawnParticle(message.Roach);
    }

    public void Handle(SpikeBallDeathMessage message)
    {
        SpawnParticle(message.SpikeBall);
    }

    private SpawnParticles SpawnParticle(GameObject element)
    {
        Vector3 position = element.transform.position;
        GameObject emitter = SRResources.Particles.DeathEnemy_Particle;
        ParticleSystem particle = _particlePool.Spawn(emitter.GetComponent<ParticleSystem>(), position, Quaternion.identity);
        particle.Play();
        return this;
    }
}
