using UnityEngine;
using System.Collections;
using PathologicalGames;

public class SpawnParticles : MonoBehaviourEx, IHandle<RoachDeathMessage>, IHandle<SpikeBallDeathMessage>, IHandle<AstronautDeathMessage>, IHandle<SpawnRoachParticleMessage>
{

    private SpawnPool _particlePool;

    private GameObject _deathRoachParticle;
    private GameObject _deathSpikeBallParticle;
    private GameObject _deathAstronautParticle;

    private GameObject _spawnRoachParticle;

    //private Transform _astronautTransform;

    public SpawnParticles Initialize(GameObject astronaut)
    {
        //_astronautTransform = astronaut.transform;
        return this;
    }


    // Use this for initialization
    void Start ()
	{
	    _particlePool = GetComponent<SpawnPool>();

        _deathRoachParticle = SRResources.Core.Particles.RoachExplosion;
        _deathSpikeBallParticle = SRResources.Core.Particles.SpikeExplosion;
        _deathAstronautParticle = SRResources.Core.Particles.AstronautExplosion;

        _spawnRoachParticle = SRResources.Core.Particles.SmokeAppear;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Handle(RoachDeathMessage message)
    {
        SpawnParticle(message.Roach, _deathRoachParticle);
    }

    public void Handle(SpikeBallDeathMessage message)
    {
        SpawnParticle(message.SpikeBall, _deathSpikeBallParticle);
    }

    public void Handle(AstronautDeathMessage message)
    {
        SpawnParticle(message.Astronaut, _deathAstronautParticle);
    }

    public void Handle(SpawnRoachParticleMessage message)
    {
        SpawnParticle(message.Roach, _spawnRoachParticle);
    }

    private SpawnParticles SpawnParticle(GameObject element, GameObject particleType)
    {
        Vector3 position = element.transform.position;
        GameObject emitter = particleType;
        _particlePool.Spawn(emitter.GetComponent<ParticleSystem>(), position, Quaternion.identity);
        return this;
    }

    
}
