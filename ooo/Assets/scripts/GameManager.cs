using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject startBaseSerialize;
    
    public static List<Harvestable> harvestables = new List<Harvestable>();
    public static GameObject startBase;
    public static GameObject forge;

    private void Start()
    {
        startBase = startBaseSerialize;
    }

    private static ObjectType GetObjectByEntity(EntityType entityType)
    {
        return entityType switch
        {
            EntityType.Harvester => ObjectType.Wood,
            EntityType.Miner => ObjectType.Rock,
            _ => throw new ArgumentOutOfRangeException(nameof(entityType), entityType, null)
        };
    }

    public static Harvestable GetHarvestable(EntityType entityType)
    {
        if (harvestables.Count == 0)
            return null;
        
        ObjectType typeNeeded = GetObjectByEntity(entityType);
        foreach (Harvestable elem in harvestables)
        {
            if (elem.type == typeNeeded)
            {
                return elem;
            }
        }

        return null;
    }
}
