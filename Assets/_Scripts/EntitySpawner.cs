using UnityEngine;
using System.Collections;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField]
    private LayerMask _avoidSpawnInLayers;


    void Start()
    {
        this.InitializeRoachPool();
    }

    public EntitySpawner RandomSpawnRoaches(int numRoaches)
    {
        for (int i = 0; i < numRoaches; i++)
        {
            Vector2 tempPosition = getAvaliablePosition();
        }
        return this;
    }

    private Vector2 getAvaliablePosition()
    {
        return new Vector2();
    }

    private EntitySpawner InitializeRoachPool()
    {
        GameObject roachPool = SRResources.Pools.Roach_Pool.Instantiate();
        roachPool.name = "Roach_Pool";
        roachPool.transform.parent = this.gameObject.transform;
        return this;
    }

  


}
