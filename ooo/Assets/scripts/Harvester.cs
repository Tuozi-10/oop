using System.Collections.Generic;
using UnityEngine;

public class Harvester : Entity
{
    [SerializeField] private HarvestManager.Type harvesterType;
    
    private int _materialCarried;
    private int _maxCarry;

    private void Start()
    {
        _moveSpeed = HarvestManager.Instance.moveSpeed;
        _idleRange = HarvestManager.Instance.idleRange;
        _detectionRadius = HarvestManager.Instance.detectionRadius;
        _maxCarry = HarvestManager.Instance.maxCarry;
        
        hasGameObjectAsTarget = true;
        SetTarget((int)harvesterType);
    }
    protected override void Interact(GameObject otherGameObject)
    {
        if (CompareTag("Harvestable"))
        {
            StartCoroutine(otherGameObject.GetComponent<Harvestable>().DesActivate());
        }

        if (CompareTag("MainHouse"))
        {
            otherGameObject.GetComponent<MainHouse>().AddToStorage(harvesterType, _materialCarried);
            _materialCarried = 0;
        }
        
        otherGameObject.SetActive(false);
        _materialCarried++;
    }
    
    private void Update()
    {
        if (_materialCarried > _maxCarry)
        {
            targetGameObject = MainHouse.Instance.gameObject;
        }
    }

    private void SetTarget(int target)
    {
        switch (target)
        {
            case 0 :
                targetGameObject = GiveHarvFromList(HarvestManager.Instance.woodList);
                break;
            case 1 :
                targetGameObject = GiveHarvFromList(HarvestManager.Instance.rockList);
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
