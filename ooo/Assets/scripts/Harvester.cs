using System;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : Entity
{
    public static List<Harvester> listHarvester = new List<Harvester>();
    
    [SerializeField] private GameObject house;
    
    [SerializeField] public Recoltable.Type myType;

    private void Awake()
    {
        listHarvester.Add(this);
    }

    public override Vector2 TargetWalkPos()
    {
        if (hasRessources)
        {
            return house.transform.position;
        }
        else
        {
            return Recoltable.closestRecoltable(myType, transform.position).transform.position;
        }
    }
    
}
