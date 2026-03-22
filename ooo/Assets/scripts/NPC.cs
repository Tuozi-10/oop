using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Entity
{
    
    [SerializeField] private GameObject forge;
    
    // ca c'est moyen, ton NPC devrait pas stocker lui meme le prix des marteaux, sinon tu peux avoir des prix différents suivant les différents NPCs
    // dans ce cas plusieurs choix:
    // scriptable pour le prix
    // constante
    // appeller un script manager ( genre maison ) et que lui stock le prix en serializable que tu pourras pas avoir duppliqué
    [SerializeField] private int boisCraft;
    [SerializeField] private int pierreCraft;
    [SerializeField] private bool inventoryFull;
    [SerializeField] private bool hasSword;
    
    private void Update()
    {
        
        if (stock.bois >= boisCraft && stock.pierre >= stock.pierre && !inventoryFull)
        {
            Walk(stock.transform.position);
        }
        else
        {
            Walk();
        }
        
        if (CheckDistance(stock.transform.position)) 
        {
            if (!hasSword && stock.bois >= boisCraft && stock.pierre >= pierreCraft)
            {
                inventoryFull = true;
                stock.bois -= boisCraft;
                stock.pierre -= pierreCraft;
                Walk(forge.transform.position);
            }
            else if(hasSword)
            {
                stock.sword++;
                hasSword = false;
            }

        }

        if (CheckDistance(forge.transform.position))
        {
            if (inventoryFull)
            {
                inventoryFull = false;
                hasSword = true;
                Walk(stock.transform.position);
            }
        }
        
    }


    
    
    
}
