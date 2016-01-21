using UnityEngine;
using System.Collections;
using PathologicalGames;
using System;
using Random = UnityEngine.Random;

public class EntitySpawner : MonoBehaviourEx, IHandle<RoachDeathMessage>, IHandle<PizzaEatenMessage>, IHandle<SpikeBallDeathMessage>
{
    private SpawnPool _roachPool;
    private SpawnPool _spikeBallPool;
    private SpawnPool _pizzaPool;

    private WaveManager _waveManager;

    public EntitySpawner InitializeSpawner(WaveManager waveManager)
    {
        this.InitializeRoachPool()
            .InitializeSpikeBallPool()
            .InitializePizzaPool();
        _waveManager = waveManager;
        return this;
    }

    public EntitySpawner SpawnEntity(string entity, Vector2 position)
    {
        switch (entity)
        {
            case "roach":
                Transform _roachTransform = _roachPool.Spawn(SRResources.Core.Characters.Roach, position, Quaternion.identity);
                _roachTransform.gameObject.GetComponent<Roach>().WakeUp();
                return this;
            case "Spikeball":
                Transform _spikeballTransform = _spikeBallPool.Spawn(SRResources.Core.Characters.Spikeball, position, Quaternion.identity);
                _spikeballTransform.gameObject.GetComponent<SpikeBall>().WakeUp();
                return this;
            case "pizza":
                Transform _pizzaTransform = _pizzaPool.Spawn(SRResources.Core.Items.PizzaSlize, position, Quaternion.identity);
                _pizzaTransform.gameObject.GetComponent<Pizza>().WakeUp();
                return this;
        }
        return this;
    }

    public EntitySpawner Reset()
    {
        _roachPool.DespawnAll();
        _spikeBallPool.DespawnAll();
        _pizzaPool.DespawnAll();
        return this;
    }

    public void Handle(SpikeBallDeathMessage message)
    {
        _waveManager.DiscountEntity("Spikeball");
        this.DespawnObject(_spikeBallPool, message.SpikeBall);
    }

    public void Handle(RoachDeathMessage message)
    {
        _waveManager.DiscountEntity("roach");
        this.DespawnObject(_roachPool, message.Roach);
    }

    public void Handle(PizzaEatenMessage message)
    {
        _waveManager.DiscountEntity("pizza");
        this.DespawnObject(_pizzaPool, message.Pizza);
    }

    private EntitySpawner DespawnObject(SpawnPool pool, GameObject target)
    {
        pool.Despawn(target.transform);
        return this;
    }

    private EntitySpawner InitializeRoachPool()
    {
        GameObject roachPool = SRResources.Core.Pools.Roach_Pool.Instantiate();
        roachPool.name = "Roach_Pool";
        roachPool.transform.parent = this.gameObject.transform;
        _roachPool = roachPool.GetComponent<SpawnPool>();
        return this;
    }

    private EntitySpawner InitializeSpikeBallPool()
    {
        GameObject spikeBallPool = SRResources.Core.Pools.SpikeBall_Pool.Instantiate();
        spikeBallPool.name = "SpikeBall_Pool";
        spikeBallPool.transform.parent = this.gameObject.transform;
        _spikeBallPool = spikeBallPool.GetComponent<SpawnPool>();
        return this;
    }

    private EntitySpawner InitializePizzaPool()
    {
        GameObject pizzaPool = SRResources.Core.Pools.Pizza_Pool.Instantiate();
        pizzaPool.name = "Pizza_Pool";
        pizzaPool.transform.parent = this.gameObject.transform;
        _pizzaPool = pizzaPool.GetComponent<SpawnPool>();
        return this;
    }

}
