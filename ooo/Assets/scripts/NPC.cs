using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Entity
{
    [SerializeField] private stock stock;
    [SerializeField] private int boisCraft;
    [SerializeField] private int pierreCraft;
    [SerializeField] private GameObject forge;
    
    private void Update()
    {
        if (stock.pierre >= pierreCraft && stock.bois >= boisCraft)
        {
            targetPosition = forge.transform.position;
            
            
            
        }
        
        else 
        {
            if (Vector3.Distance(transform.position, targetPosition) < 0.1)
            {
                Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5.5f, 5.5f), 0);
                targetPosition = randomPosition;
            }

            
        }
    }
}
