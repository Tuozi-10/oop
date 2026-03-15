using System;
using UnityEngine;


public class NPC : Entity
{
    [SerializeField] private GameObject _forge;
    private bool _carrySwordMaterials;
    
    private void Start()
    {
        _moveSpeed = HarvestManager.Instance.moveSpeed / 4;
        _detectionRadius = HarvestManager.Instance.detectionRadius;
        _maxIdleRange = new Vector2(-3f, 0.5f);
        _minIdleRange = new Vector2(-10f, -3f);
        SetRandomTargetPos();
    }

    private void Update()
    {
        if (MainHouse.Instance.mainRockStorage <= 50
            || MainHouse.Instance.mainWoodStorage <= 30
            || _carrySwordMaterials) return;
        SetTarget(MainHouse.Instance.gameObject);
    }

    protected override void Interact(GameObject otherGameObject)
    {
        if (otherGameObject.CompareTag("Forge"))
        {
            _carrySwordMaterials = false;
            MainHouse.Instance.mainSwordStorage++;
            ClearTarget();
        }
        else if (otherGameObject.CompareTag("MainHouse"))
        {
            MainHouse.Instance.mainRockStorage -= 50;
            MainHouse.Instance.mainWoodStorage -= 30;
            _carrySwordMaterials = true;
            SetTarget(_forge);
        }
    }

    private void SetTarget(GameObject obj)
    {
        hasGameObjectAsTarget = true;
        targetGameObject = obj;
        targetPos = obj.transform.position;
    }

    private void ClearTarget()
    {
        hasGameObjectAsTarget = false;
        targetGameObject = null;
        SetRandomTargetPos();
    }
}
