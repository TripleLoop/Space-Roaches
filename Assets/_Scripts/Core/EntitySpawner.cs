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

    public EntitySpawner SpawnEntity(string entity, Vector2 position)
    {
        if (entity == "roach")
        {
            _roachPool.Spawn(SRResources.Characters.Roach, position, Quaternion.identity);
            return this;
        }
        if (entity == "spikeball")
        {
            _spikeBallPool.Spawn(SRResources.Characters.Spikeball, position, Quaternion.identity);
            return this;
        }
        if (entity == "pizza")
        {
            _pizzaPool.Spawn(SRResources.Items.PizzaSlize, position, Quaternion.identity);
            return this;
        }
        return this;
    }

    private EntitySpawner DespawnObject(SpawnPool pool, GameObject target)
    {
        pool.Despawn(target.transform);
        return this;
    }

    private EntitySpawner InitializeRoachPool()
    {
        GameObject roachPool = SRResources.Pools.Roach_Pool.Instantiate();
        roachPool.name = "Roach_Pool";
        roachPool.transform.parent = this.gameObject.transform;
        _roachPool = roachPool.GetComponent<SpawnPool>();
        return this;
    }

    private EntitySpawner InitializeSpikeBallPool()
    {
        GameObject spikeBallPool = SRResources.Pools.SpikeBall_Pool.Instantiate();
        spikeBallPool.name = "SpikeBall_Pool";
        spikeBallPool.transform.parent = this.gameObject.transform;
        _spikeBallPool = spikeBallPool.GetComponent<SpawnPool>();
        return this;
    }

    private EntitySpawner InitializePizzaPool()
    {
        GameObject pizzaPool = SRResources.Pools.Pizza_Pool.Instantiate();
        pizzaPool.name = "Pizza_Pool";
        pizzaPool.transform.parent = this.gameObject.transform;
        _pizzaPool = pizzaPool.GetComponent<SpawnPool>();
        return this;
    }

    public EntitySpawner InitializeSpawner(WaveManager waveManager)
    {
        this.InitializeRoachPool()
            .InitializeSpikeBallPool()
            .InitializePizzaPool();
        _waveManager = waveManager;
        return this;
    }

    public void Handle(SpikeBallDeathMessage message)
    {
        _waveManager.DiscountEntity("spikeball");
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
}
