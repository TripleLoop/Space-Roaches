﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WaveManager : MonoBehaviourEx
{
    [SerializeField]
    private LayerMask _avoidSpawnInLayers;
    private EntitySpawner _entitySpawner;

    private Vector2 _originPosition;
    private Vector2 _endPosition;

    private int _pizzaCount;
    private int _roachCount;
    private int _spikeBallCount;

    public WaveManager EntitySpawn()
    {
        int number = Random.Range(5, 16);
        StartCoroutine(SpawnRoutine(number));
        return this;
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
        for (int i = 0; i < spawnNumber; i++)
        {
            EntityWeight tempChosen = this.RandomWeightedChooser(GetCustomWeights());
            CountEntity(tempChosen.Name);
            Vector2 tempPosition = GetAvaliablePosition();
            _entitySpawner.SpawnEntity(tempChosen.Name, tempPosition);
            yield return null;
        }
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

    private Vector2 RandomPosition()
    {
        float xPosition = Random.Range(_originPosition.x, _endPosition.x);
        float yPosition = Random.Range(_originPosition.y, _endPosition.y);
        return new Vector2(xPosition, yPosition);
    }

    public WaveManager InitializeWaveManager()
    {
        _originPosition = new Vector2(-6.07f, 3.26f);
        _endPosition = new Vector2(5.81f, -3.12f);
        InitializeEntitySpawner();
        return this;
    }

    private WaveManager InitializeEntitySpawner()
    {
        GameObject entitySpawner = SRResources.Base.EntitySpawner.Instantiate();
        entitySpawner.name = "entitySpawner";
        entitySpawner.transform.parent = this.gameObject.transform;
        _entitySpawner = entitySpawner.GetComponent<EntitySpawner>();
        _entitySpawner.InitializeSpawner(this);
        return this;
    }

    private WaveManager CountEntity(string entity)
    {
        if (entity == "roach")
        {
            _roachCount++;
            return this;
        }
        if (entity == "spikeball")
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
            tempweights.Add(new EntityWeight("spikeball", 23));
        }
        if (_pizzaCount == 0)
        {
            tempweights.Add(new EntityWeight("pizza", 2));
        }
        tempweights.Add(new EntityWeight("roach", 75));
        return tempweights;
    }


    public WaveManager DiscountEntity(string entity)
    {
        if (entity == "roach")
        {
            _roachCount--;
            return this;
        }
        if (entity == "spikeball")
        {
            _spikeBallCount--;
            return this;
        }
        if (entity == "pizza")
        {
            _pizzaCount--;
            return this;
        }
        return this;
    }

}
