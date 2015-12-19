using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class WaveManager : MonoBehaviourEx
{
    private SpaceRoaches _spaceRoaches;
    private EntitySpawner _entitySpawner;

    [SerializeField]
    private LayerMask _avoidSpawnInLayers;

    private Vector2 _originPosition;
    private Vector2 _endPosition;

    private int _pizzaCount;
    private int _roachCount;
    private int _spikeBallCount;

    private bool _inPizzaCooldown;
    private IEnumerator _pizzaCooldown;

    private bool _inSpawnRoutine;
    private IEnumerator _spawnRoutine;

    public WaveManager InitializeWaveManager()
    {
        _originPosition = new Vector2(-6.07f, 3.26f);
        _endPosition = new Vector2(5.81f, -3.12f);
        InitializeEntitySpawner();
        return this;
    }

    public WaveManager EntitySpawn()
    {
        int number = Random.Range(5, 16);
        _spawnRoutine = SpawnRoutine(number);
        StartCoroutine(_spawnRoutine);
        return this;
    }

    public WaveManager DiscountEntity(string entity)
    {
        switch (entity)
        {
            case "roach":
                _roachCount--;
                break;
            case "Spikeball":
                _spikeBallCount--;
                break;
            case "pizza":
                _pizzaCooldown = PizzaCooldown();
                StartCoroutine(_pizzaCooldown);
                _pizzaCount--;
                break;
        }
        if (CurrentElementCount() == 0)
        {
            _spaceRoaches.FasterWaveCycle();
        }
        return this;
    }

    public WaveManager Reset()
    {
        _pizzaCount = 0;
        _roachCount = 0;
        _spikeBallCount = 0;
        if (_inPizzaCooldown)
        {
            StopCoroutine(_pizzaCooldown);
            _inPizzaCooldown = false;
        }
        if (_inSpawnRoutine)
        {
            StopCoroutine(_spawnRoutine);
            _inSpawnRoutine = false;
        }
        _entitySpawner.Reset();
        return this;
    }

    private int CurrentElementCount()
    {
        return _roachCount + _spikeBallCount + _pizzaCount;
    }

    private EntityWeight RandomWeightedChooser(List<EntityWeight> entityWeights)
    {
        int totalWeight = entityWeights.Sum(c => c.Weight);
        int choice = Random.Range(0, totalWeight);
        int sum = 0;
        foreach (var obj in entityWeights)
        {
            for (int i = sum; i < obj.Weight + sum; i++)
            {
                if (i >= choice)
                {
                    return obj;
                }
            }
            sum += obj.Weight;
        }

        return entityWeights.First();
    }

    private IEnumerator SpawnRoutine(int spawnNumber)
    {
        _inSpawnRoutine = true;
        for (int i = 0; i < spawnNumber; i++)
        {
            List<EntityWeight> weights = GetCustomWeights();
            if (weights.Count == 0)
            {
                continue;
            }
            EntityWeight tempChosen = this.RandomWeightedChooser(weights);
            CountEntity(tempChosen.Name);
            Vector2 tempPosition = GetAvaliablePosition();
            _entitySpawner.SpawnEntity(tempChosen.Name, tempPosition);
            yield return null;
        }
        _inSpawnRoutine = false;
    }

    private Vector2 GetAvaliablePosition()
    {
        int colliderCount;
        int tries = 0;
        Vector2 testedPosition;
        Collider2D[] collidersDetected = new Collider2D[2];
        float radius = 0.45f;
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

    private Vector2 RandomPosition()
    {
        float xPosition = Random.Range(_originPosition.x, _endPosition.x);
        float yPosition = Random.Range(_originPosition.y, _endPosition.y);
        return new Vector2(xPosition, yPosition);
    }


    private WaveManager CountEntity(string entity)
    {
        if (entity == "roach")
        {
            _roachCount++;
            return this;
        }
        if (entity == "Spikeball")
        {
            _spikeBallCount++;
            return this;
        }
        if (entity == "pizza")
        {
            _pizzaCount++;
            return this;
        }
        return this;
    }

    private List<EntityWeight> GetCustomWeights()
    {
        List<EntityWeight> tempweights = new List<EntityWeight>();
        if (_spikeBallCount < 4)
        {
            tempweights.Add(new EntityWeight("Spikeball", 23));
        }
        if (_pizzaCount == 0 && !_inPizzaCooldown)
        {
            tempweights.Add(new EntityWeight("pizza", 2));
        }
        if (_roachCount < 15)
        {
            tempweights.Add(new EntityWeight("roach", 75));
        }
        return tempweights;
    }

    private IEnumerator PizzaCooldown()
    {
        _inPizzaCooldown = true;
        yield return new WaitForSeconds(30f);
        _inPizzaCooldown = false;
    }

    public WaveManager SetSpaceRoaches(SpaceRoaches spaceRoaches)
    {
        _spaceRoaches = spaceRoaches;
        return this;
    }

    private WaveManager InitializeEntitySpawner()
    {
        GameObject entitySpawner = SRResources.Core.Base.EntitySpawner.Instantiate();
        entitySpawner.name = "entitySpawner";
        entitySpawner.transform.parent = this.gameObject.transform;
        _entitySpawner = entitySpawner.GetComponent<EntitySpawner>();
        _entitySpawner.InitializeSpawner(this);
        return this;
    }

}
