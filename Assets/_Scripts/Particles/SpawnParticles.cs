using UnityEngine;
using System.Collections;
using PathologicalGames;

public class SpawnParticles : MonoBehaviourEx, IHandle<RoachDeathMessage>, IHandle<SpikeBallDeathMessage>, IHandle<AstronautDeathMessage>
{

    private SpawnPool _particlePool;

    private GameObject _deathEnemyParticle;
    private GameObject _dashParticle;
    private GameObject _deathAstronautParticle;

    private Transform _astronautTransform;

    public SpawnParticles Initialize(GameObject astronaut)
    {
        _astronautTransform = astronaut.transform;
        return this;
    }


    // Use this for initialization
    void Start ()
	{
	    _particlePool = GetComponent<SpawnPool>();

        _deathEnemyParticle = SRResources.Core.Particles.RoachExplosion;
        _deathAstronautParticle = SRResources.Core.Particles.AstronautExplosion;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Handle(RoachDeathMessage message)
    {
        SpawnParticle(message.Roach, _deathEnemyParticle);
    }

    public void Handle(SpikeBallDeathMessage message)
    {
        SpawnParticle(message.SpikeBall, _deathEnemyParticle);
    }

    public void Handle(AstronautDeathMessage message)
    {
        SpawnParticle(message.Astronaut, _deathAstronautParticle);
    }

    private SpawnParticles SpawnParticle(GameObject element, GameObject particleType)
    {
        Vector3 position = element.transform.position;
        GameObject emitter = particleType;
        _particlePool.Spawn(emitter.GetComponent<ParticleSystem>(), position, Quaternion.identity);
        return this;
    }
}
