using System;
using Unity.VisualScripting;
using UnityEngine;

public class Harvester : Entity
{

    [SerializeField] private GameObject maison;
    [SerializeField] private GameObject arbre;
    [SerializeField] private GameObject pierre;
    [SerializeField] private bool inventoryFull;
    [SerializeField] private Type type;
    
    [SerializeField] private stock stock;

    private enum Type
    {
        bois,
        pierre
    }
    
    private void Update()
    {
        if (inventoryFull)
        {
            targetPosition = maison.gameObject.transform.position;
        }

        if (!inventoryFull)
        {
            if (type == Type.bois)
            {
                targetPosition = arbre.gameObject.transform.position;
            }

            if (type == Type.pierre)
            {
                targetPosition = pierre.gameObject.transform.position;
            }
            
            
        }

        
        //deposer
        if (Vector3.Distance(maison.gameObject.transform.position, transform.position) < 0.1)
        {
            inventoryFull = false;
            if (type == Type.bois)
            {
                stock.bois++;
            }

            if (type == Type.pierre)
            {
                stock.pierre++;
            }
        }
        //récolter
        if (Vector3.Distance(arbre.gameObject.transform.position, transform.position) < 0.1)
        {
            inventoryFull = true;
        }
        if (Vector3.Distance(pierre.gameObject.transform.position, transform.position) < 0.1)
        {
            inventoryFull = true;
        }
    }
    
    
    
}
