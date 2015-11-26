using UnityEngine;
using System.Collections;
using PathologicalGames;
using System;
using Random = UnityEngine.Random;

public class EntitySpawner : MonoBehaviourEx, IHandle<RoachDeathMessage>, IHandle<PizzaEatenMessage>, IHandle<SpikeBallDeathMessage>
{
    [SerializeField]
    private LayerMask _avoidSpawnInLayers;
    [SerializeField]
    private Vector2 _originPosition;
    [SerializeField]
    private Vector2 _endPosition;

    private SpawnPool _roachPool;
    private SpawnPool _spikeBallPool;
    private SpawnPool _pizzaPool;

   private bool _pizzaInWave = false;

    public EntitySpawner InitializeSpawner()
    {
        this.InitializeRoachPool()
            .InitializeSpikeBallPool()
            .InitializePizzaPool();
        return this;
    }

    public EntitySpawner EntitySpawn(int spawnNumber)
    {
        StartCoroutine(SpawnRoutine(spawnNumber));
        return this;
    }

    private Vector2 GetAvaliablePosition()
    {
        int colliderCount;
        int tries = 0;
        Vector2 testedPosition;
        Collider2D[] collidersDetected = new Collider2D[2];
        float radius = 0.3f;
        do
        {
            testedPosition = RandomPosition();
            colliderCount = Physics2D.OverlapCircleNonAlloc(testedPosition, radius, collidersDetected, _avoidSpawnInLayers);
            tries++;
            if (tries >= 15)
            {
                Debug.Log("Didn't find position after " + tries + " tries, reducing radius");
                if (radius >= 0.1)
                {
                    radius -= 0.1f;
                    tries = 0;
                    continue;
                }
                Debug.Log("Failed default position returned");
                return new Vector2();
            }
        } while (colliderCount != 0);
        return testedPosition;
    }

    private IEnumerator SpawnRoutine(int spawnNumber)
    {
        _pizzaInWave = false;
        for (int i = 0; i < spawnNumber; i++)
        {
            Vector2 tempPosition = GetAvaliablePosition();
            this.RandomSpawnEntity(tempPosition);
            yield return null;
        }
    }

    private EntitySpawner RandomSpawnEntity(Vector2 position)
    {
        float randomNumber = Random.Range(0f, 1f);
        float upperlimit = 0.98f;
        if (_pizzaInWave)
        {
            upperlimit = 1f;
        }
        if (randomNumber <= 0.75f)
        {
            _roachPool.Spawn(SRResources.Characters.Roach, position, Quaternion.identity);
            return this;
        }
        if (randomNumber > 0.75f && randomNumber <= upperlimit)
        {
            _spikeBallPool.Spawn(SRResources.Characters.Spikeball, position, Quaternion.identity);
            return this;
        }
        if (randomNumber > 0.98f)
        {
            _pizzaPool.Spawn(SRResources.Items.PizzaSlize, position, Quaternion.identity);
            _pizzaInWave = true;
            return this;
        }
        return this;
    }

    private EntitySpawner DespawnObject(SpawnPool pool, GameObject target)
    {
        pool.Despawn(target.transform);
        return this;
    }

    private Vector2 RandomPosition()
    {
        float xPosition = Random.Range(_originPosition.x, _endPosition.x);
        float yPosition = Random.Range(_originPosition.y, _endPosition.y);
        return new Vector2(xPosition, yPosition);
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

    public void Handle(RoachDeathMessage message)
    {
        this.DespawnObject(_roachPool,message.Roach);
    }

    public void Handle(PizzaEatenMessage message)
    {
        this.DespawnObject(_pizzaPool, message.Pizza);
    }

    public void Handle(SpikeBallDeathMessage message)
    {
        this.DespawnObject(_spikeBallPool, message.SpikeBall);
    }
}
