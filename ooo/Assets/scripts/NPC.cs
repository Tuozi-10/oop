using System;
using UnityEngine;


public class NPC : Entity
{
    [SerializeField] private GameObject _forge;
    private bool _carrySwordMaterials;
    
    private void Start()
    {
        SetRandomTargetPos();
    }

    private void Update()
    {
        if (MainHouse.Instance.mainRockStorage < 50 
            && MainHouse.Instance.mainWoodStorage < 30 
            && hasGameObjectAsTarget) return;
        
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
            MainHouse.Instance.mainWoodStorage -= 50;
            MainHouse.Instance.mainRockStorage -= 30;
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
        targetPos = Vector3.zero;
    }
}
