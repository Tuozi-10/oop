using System.Collections.Generic;
using UnityEngine;

public class Harvester : Entity
{
    public static List<Recoltable> recoltableList = new List<Recoltable>();
    
    [SerializeField] private bool inventoryFull;
    [SerializeField] private Recoltable.RecoltableType HarvesterType;
    private Recoltable selectedRecoltable;

    private void Update()
    {
        if (inventoryFull)
        {
            Walk(stock.transform.position);
        }

        if (!inventoryFull)
        {
            Walk(FoundNearest());
        }

        
        //deposer
        if (CheckDistance(stock.transform.position) && inventoryFull)
        {
            inventoryFull = false;
            if (HarvesterType == Recoltable.RecoltableType.bois)
            {
                stock.bois++;
            }

            if (HarvesterType == Recoltable.RecoltableType.pierre)
            {
                stock.pierre++;
            }
            
        }
        
        //récolter
        if (CheckDistance(selectedRecoltable.transform.position))
        {
            inventoryFull = true;
            selectedRecoltable.DisableRecoltable();
        }

    }

    private Vector3 FoundNearest()
    {
        Recoltable nearestRecoltable = null;
        foreach (var recoltable in recoltableList)
        {
            if (recoltable.recoltableType == HarvesterType && recoltable.isEnabled && !recoltable.isChosen)
            {
                if (nearestRecoltable == null)
                {
                    nearestRecoltable = recoltable;
                }
                
                if (Vector3.Distance(transform.position, recoltable.transform.position) < Vector3.Distance(transform.position, nearestRecoltable.transform.position))
                {
                    nearestRecoltable = recoltable;
                }
            }
        }

        selectedRecoltable = nearestRecoltable;
        //selectedRecoltable.isChosen = true;
        return nearestRecoltable.transform.position;
    }
}
