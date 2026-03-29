using System;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Entity
{
    public static List<NPC> listNPC = new List<NPC>();
    
    [SerializeField] private GameObject Forge;
    [SerializeField] private GameObject House;
    
    private void Awake()
    {
        listNPC.Add(this);
    }
    
    public bool canForge = false;

    private Recoltable.Type myType = Recoltable.Type.Sword;
    
    public override Vector2 TargetWalkPos()
    {
        if (hasRessources)
        {
            return House.transform.position;
        }
        if (canForge)
        {
            return Forge.transform.position;
        }
        Vector2 posToWalk = new Vector2();
        posToWalk.x = Random.Range(-10, 10);
        posToWalk.y = Random.Range(-10, 10);
        return posToWalk;
    }

    // pas giga giga fan du retrait instant de tes ressources quand il peut aller forger, et des valeurs en dur,
    // et en bonus dans l'update, mais ca reste fonctionnel
    private void Update()
    {
        if (GameManager.instance.wood >= 5 && GameManager.instance.stone >= 3)
        {
            GameManager.instance.wood -= 5;
            GameManager.instance.stone -= 3;
            canForge = true;
        }
    }
}