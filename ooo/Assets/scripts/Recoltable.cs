using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoltable : MonoBehaviour
{
    public static List<Recoltable> listRecoltables = new List<Recoltable>();
    
    public enum Type
    {
        Wood,
        Stone,
        Sword
    }

    [SerializeField] private Type myType;

    private bool isActive = true;

    private void Awake()
    {
        listRecoltables.Add(this);
    }

    private void Update()
    {
        CollisionHarvester();
    }

    public static Recoltable closestRecoltable(Type recoltableType, Vector2 posHarvester)
    {
        Recoltable recoltableToHarvest = null;
        
        foreach (var recoltable in listRecoltables)
        {
            if (recoltable.isActive == false)
            {
                continue;
            }

            if (recoltable.myType == recoltableType)
            {
                if (recoltableToHarvest == null )
                {
                    recoltableToHarvest = recoltable;
                }
                else if (Vector2.Distance(recoltableToHarvest.transform.position, posHarvester) >= Vector2.Distance(recoltable.transform.position, posHarvester))
                {
                    recoltableToHarvest = recoltable;
                }
            }
        }
        return recoltableToHarvest;
    }

    public void CollisionHarvester()
    {
        foreach (var harvester in Harvester.listHarvester)
        {
            if (Vector2.Distance(harvester.transform.position, transform.position) <= 1 && isActive)
            {
                harvester.hasRessources = true;
                ChangeState();
                break;
            }
        }
    }
    
    private void ChangeState()
    {
        isActive = !isActive;
        if (isActive == false)
        {
            StartCoroutine(WaitSetActive());
            
        }
    }

    private IEnumerator WaitSetActive()
    {
        yield return new WaitForSeconds(7.5f);
        ChangeState();
    }
}
