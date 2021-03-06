﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;
using LocalConfig = Config.WaveManager;

public class WaveManager : MonoBehaviourEx
{
    

    public WaveManager InitializeWaveManager()
    {
        _originPosition = LocalConfig.SpawnArea.OriginPosition;
        _endPosition = LocalConfig.SpawnArea.EndPosition;
        _maxSpawnElements = LocalConfig.Wave.MaxElements + 1;
        _minSpawnElements = LocalConfig.Wave.MaxTries;
        InitializeEntitySpawner();
        return this;
    }

    public WaveManager SpawnWave(WaveData waveData)
    {
        _waveDataConditions = waveData;
        _minSpawnElements = waveData.MinPerWave[0] + waveData.MinPerWave[1] + waveData.MinPerWave[2];
        _maxSpawnElements = waveData.MaxPerWave[0] + waveData.MaxPerWave[1] + waveData.MaxPerWave[2];
        int number = Random.Range(_minSpawnElements, _maxSpawnElements);
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
        if (_roachCount == 0)
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
        _tempPizzaCount = 0;
        _tempRoachCount = 0;
        _tempSpikeBallCount = 0;

        _inSpawnRoutine = true;
        for (int i = 0; i < spawnNumber; i++)
        {
            List<EntityWeight> weights = GetCustomWeights();
            if (weights.Count == 0)
            {
                continue;
            }
            EntityWeight tempChosen = this.RandomWeightedChooser(weights);
            if (RangeReached(tempChosen.Name))
            {
                i--;
                continue;
            }
            CountEntity(tempChosen.Name);
            Vector2 tempPosition = GetAvaliablePosition();
            _entitySpawner.SpawnEntity(tempChosen.Name, tempPosition);
            yield return null;
        }
        _inSpawnRoutine = false;
    }

    private bool RangeReached(string entity)
    {
        if (entity == "roach" && _waveDataConditions.MaxPerWave[0] == _tempRoachCount)
        {
            return true;
        }
        if (entity == "Spikeball" && _waveDataConditions.MaxPerWave[1] == _tempSpikeBallCount)
        {
            return true;
        }
        if (entity == "pizza" && _waveDataConditions.MaxPerWave[2] == _tempPizzaCount)
        {
            return true;
        }
        return false;
    }

    private Vector2 GetAvaliablePosition()
    {
        int colliderCount;
        int tries = 0;
        Vector2 testedPosition;
        Collider2D[] collidersDetected = new Collider2D[2];
        float radius = LocalConfig.Wave.InitialRadius;
        do
        {
            testedPosition = RandomPosition();
            colliderCount = Physics2D.OverlapCircleNonAlloc(testedPosition, radius, collidersDetected, _avoidSpawnInLayers);
            tries++;
            if (tries >= LocalConfig.Wave.MaxTries)
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
            _tempRoachCount++;
            return this;
        }
        if (entity == "Spikeball")
        {
            _spikeBallCount++;
            _tempSpikeBallCount++;
            return this;
        }
        if (entity == "pizza")
        {
            _pizzaCount++;
            _tempPizzaCount++;
            return this;
        }
        return this;
    }

    private List<EntityWeight> GetCustomWeights()
    {
        List<EntityWeight> tempweights = new List<EntityWeight>();
        if (_spikeBallCount < _waveDataConditions.LimitsInScene[1])
        {
            tempweights.Add(new EntityWeight("Spikeball", _waveDataConditions.SpawnWeights[1]));
        }
        if (_pizzaCount < _waveDataConditions.LimitsInScene[2] && !_inPizzaCooldown)
        {
            tempweights.Add(new EntityWeight("pizza", _waveDataConditions.SpawnWeights[2]));
        }
        if (_roachCount < _waveDataConditions.LimitsInScene[0])
        {
            tempweights.Add(new EntityWeight("roach", _waveDataConditions.SpawnWeights[0]));
        }
        return tempweights;
    }

    private IEnumerator PizzaCooldown()
    {
        _inPizzaCooldown = true;
        yield return new WaitForSeconds(LocalConfig.Pizza.Cooldown);
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

    private SpaceRoaches _spaceRoaches;
    private EntitySpawner _entitySpawner;

    [SerializeField]
    private LayerMask _avoidSpawnInLayers;

    private Vector2 _originPosition;
    private Vector2 _endPosition;

    private int _maxSpawnElements;
    private int _minSpawnElements;

    private int _pizzaCount;
    private int _roachCount;
    private int _spikeBallCount;

    private int _tempPizzaCount;
    private int _tempRoachCount;
    private int _tempSpikeBallCount;

    private bool _inPizzaCooldown;
    private IEnumerator _pizzaCooldown;

    private bool _inSpawnRoutine;
    private IEnumerator _spawnRoutine;

    //WaveData specification
    private WaveData _waveDataConditions;
}
