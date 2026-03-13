using System;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : NPC
{
    public Recoltable.Recoltabletype recoltabletype;
    public bool hasRessources = false;
    
    private static List<Harvester> allHarvesters = new List<Harvester>();
    
    private void Harvest()
    {
        foreach (var Harvester in allHarvesters)
        {
            WalkTo(Recoltable.GetClosestRecoltable(recoltabletype, Harvester.transform.position).transform.position);
        }
       
    }
}
