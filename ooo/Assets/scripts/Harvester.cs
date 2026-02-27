using System;
using UnityEngine;

public class Harvester : Npc
{
    [SerializeField] private materialType materials;

    private enum materialType
    {
        wood = 1,
        stone = 2
    }
    
    protected override Vector2 GetTargetPosition()
    {
        if (Vector3.Distance(transform.position, workStation.transform.position) < 1)
        {
            return home.transform.position;
        }

        if (materials == materialType.wood)
        {
            Home.instance.AddWood();
        }
        else
        {
            Home.instance.AddStone();
        }
        return workStation.transform.position;
    }
}
