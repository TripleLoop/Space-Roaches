using UnityEngine;
using System.Collections;
using PathologicalGames;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    private LayerMask _avoidSpawnInLayers;
    [SerializeField]
    private Vector2 _originPosition;
    [SerializeField]
    private Vector2 _endPosition;

    private SpawnPool _roachPool;

    public EntitySpawner InitializeSpawner()
    {
        this.InitializeRoachPool();
        return this;
    }

    public EntitySpawner RandomSpawnRoaches(int numRoaches)
    {
        StartCoroutine(SpawnRoutine(numRoaches));
        return this;
    }

    private Vector2 GetAvaliablePosition()
    {
        int colliderCount;
        int tries = 0;
        Vector2 testedPosition;
        Collider2D[] collidersDetected = new Collider2D[2];
        do
        {
            testedPosition = RandomPosition();
            colliderCount = Physics2D.OverlapCircleNonAlloc(testedPosition, 0.3f, collidersDetected, _avoidSpawnInLayers);
            tries++;
            if (tries >= 15)
            {
                Debug.Log("Failed! didn't find avaiable position after " + tries + " tries");
                return new Vector2();
            }
        } while (colliderCount != 0);
        return testedPosition;
    }

    private IEnumerator SpawnRoutine(int numRoaches)
    {
        for (int i = 0; i < numRoaches; i++)
        {
            Vector2 tempPosition = GetAvaliablePosition();
            _roachPool.Spawn(SRResources.Characters.Roach, tempPosition, Quaternion.identity);
            yield return null;
        }
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




}
