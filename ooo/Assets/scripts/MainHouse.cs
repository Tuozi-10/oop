using System;
using UnityEngine;
using static HarvestManager.Type;


public class MainHouse : MonoBehaviour
{
    public static MainHouse Instance;
    public int mainWoodStorage;
    public int mainRockStorage;
    public int mainSwordStorage;
    
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddToStorage(HarvestManager.Type type, int quantity)
    {
        switch (type)
        {
            case Rock :
                mainRockStorage += quantity;
                return;
            case Wood :
                mainWoodStorage += quantity;
                return;
        }
    }
}
