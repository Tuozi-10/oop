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
            var targetHarv = otherGameObject.GetComponent<Harvestable>();
            if (!targetHarv.activated)
            {
                SetTarget((int)harvesterType);
                return;
            }
            StartCoroutine(targetHarv.DesActivate());
            SetTarget(2);
            _amountCarried += _onHarvestValue;
        }
        else if (otherGameObject.CompareTag("MainHouse"))
        {
            otherGameObject.GetComponent<MainHouse>().AddToStorage(harvesterType, _amountCarried);
            SetTarget((int)harvesterType);
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
        for (int i = 0; i < 20; i++)
        {
            var harvObj = harvList[Random.Range(0, harvList.Count - 1)];
            if (!harvObj.GetComponent<Harvestable>().activated) continue;
            return harvObj;
        }

        return null;
    }
}
