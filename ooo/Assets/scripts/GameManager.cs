using System;
using System.Collections.Generic;
using Entities;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject startBaseSerialize;
    [SerializeField] private GameObject forgeSerialize;
    
    public static List<Harvestable> harvestables = new List<Harvestable>();
    public static GameObject startBase;
    public static GameObject forge;

    public static Action TotalReached;

    private static int _totalWood;
    public static int TotalWood
    {
        get => _totalWood;
        set
        {
            _totalWood = value;
            UiManager.Instance.ActualiseUi(ObjectType.Wood, _totalWood);
            CheckTotals();
        }
    }

    private static int _totalRock;
    public static int TotalRock
    {
        get => _totalRock;
        set
        {
            _totalRock = value;
            UiManager.Instance.ActualiseUi(ObjectType.Rock, _totalRock);
            CheckTotals();
        }
    }
    
    private static int _totalSword;
    public static int TotalSword
    {
        get => _totalSword;
        set
        {
            _totalSword = value;
            UiManager.Instance.ActualiseUi(ObjectType.Sword, _totalSword);
        }
    }
    
    private static void CheckTotals() 
    {
        if (_totalWood >= 5 && _totalRock >= 5) 
        {
            TotalReached.Invoke();
        }
    }
    
    

    private void Start()
    {
        startBase = startBaseSerialize;
        forge = forgeSerialize;
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
