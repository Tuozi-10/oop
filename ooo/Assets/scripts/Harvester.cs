using System;
using UnityEngine;

public class Harvester : NPC
{
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent(Recoltable))
        {
            
        }
    }
}
