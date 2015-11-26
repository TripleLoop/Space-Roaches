using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class WaveManager : MonoBehaviourEx
{
    [SerializeField]
    private LayerMask _avoidSpawnInLayers;
    private Vector2 _originPosition;
    private Vector2 _endPosition;

    public WaveManager EntitySpawn(int spawnNumber)
    {
        StartCoroutine(SpawnRoutine(spawnNumber));
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

    private WaveManager RandomSpawnEntity(Vector2 position)
    {
        float randomNumber = Random.Range(0f, 1f);
        if (randomNumber <= 0.75f)
        {
            return this;
        }
        if (randomNumber > 0.75f)
        {
            return this;
        }
        if (randomNumber > 0.98f)
        {
            return this;
        }
        return this;
    }

    private IEnumerator SpawnRoutine(int spawnNumber)
    {
        for (int i = 0; i < spawnNumber; i++)
        {
            Vector2 tempPosition = GetAvaliablePosition();
            this.RandomSpawnEntity(tempPosition);
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
        return this;
    }

}
