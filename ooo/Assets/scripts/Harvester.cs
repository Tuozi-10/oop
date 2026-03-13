using System.Collections.Generic;
using UnityEngine;
using static HarvestManager;

public class Harvester : Entity
{
    [SerializeField] private Type harvesterType;
    
    private int _amountCarried;
    private int _onHarvestValue;

    private void Start()
    {
        _moveSpeed = Instance.moveSpeed;
        _idleRange = Instance.idleRange;
        _detectionRadius = Instance.detectionRadius;

        _onHarvestValue = harvesterType == Type.Wood ?
            Instance.onHarvestWoodValue : Instance.onHarvestRockValue;
        
        hasGameObjectAsTarget = true;
        SetTarget((int)harvesterType);
    }
    protected override void Interact(GameObject otherGameObject)
    {
        if (otherGameObject.CompareTag("Harvestable"))
        {
            print("arbre touché");
            StartCoroutine(otherGameObject.GetComponent<Harvestable>().DesActivate());
            SetTarget((int)harvesterType);
            _amountCarried += _onHarvestValue;
        }
        else if (otherGameObject.CompareTag("MainHouse"))
        {
            otherGameObject.GetComponent<MainHouse>().AddToStorage(harvesterType, _amountCarried);
            SetTarget(2);
            _amountCarried = 0;
        }
    }
    
    private void Update()
    {
        if (_amountCarried > Instance.maxCarry)
        {
            targetGameObject = MainHouse.Instance.gameObject;
        }
    }

    private void SetTarget(int target)
    {
        switch (target)
        {
            case 0 :
                targetGameObject = GiveHarvFromList(Instance.woodList);
                break;
            case 1 :
                targetGameObject = GiveHarvFromList(Instance.rockList);
                break;
            case 2 :
                targetGameObject = MainHouse.Instance.gameObject;
                break;
            default:
                break;
        }
        targetPos = targetGameObject.transform.position;
    }

    private GameObject GiveHarvFromList(List<GameObject> harvList)
    {
        for (int i = 0; i < harvList.Count;)
        {
            if (!harvList[i].GetComponent<Harvestable>().activated) continue;
            return harvList[i];
        }

        return null;
    }
}
