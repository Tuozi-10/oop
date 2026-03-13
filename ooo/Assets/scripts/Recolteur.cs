using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Recolteur : Entity
{

    // si c'est le bon on go in 
    // sinon on remet a jour le truc 

    public recoldata recoltdata;

    public Recolt targetType;
    
    public bool inventoryfull;
    
    public static int nbWoodHome = 0;
    public static int nbRockHome = 0;

    private int currentWoods;
    private int currentRocks;
    
    

    [SerializeField] private GameObject home;

    public void Start()
    {
        targetType = recoltdata.recolt;
        currentRocks = Recoltable.pierreInitial;
        currentWoods = Recoltable.boisInitial;


    }

    void Update()
    {
        setTarget();
        MovetoTargetPosition();
        if (targetTransform == transform.position)
        {
            inventoryfull = true;
            
            setTarget();
        }

        if (transform.position == home.transform.position)
        {
            inventoryfull = false;
            if (typeEntity == entityData.bucheron)
            {
                nbWoodHome++;
                currentWoods--;
                test.text = "woods : " + nbWoodHome.ToString();

            }

            if (typeEntity == entityData.mineur)
            {
                nbRockHome++;
                currentRocks--;
                test.text = "rocks : " + nbRockHome.ToString();

            }
            
            
        }
        
        
    }



    public Vector3 researchtarget()
    {


        foreach (var recoltable in Recoltable.recoltables)
        {
            if (recoltable.recolt == targetType && !inventoryfull)
            {
                return recoltable.transform.position;
                
            }
        }
        
        return home.transform.position;
    }

    public void setTarget()
    {
        var target = researchtarget();
        targetTransform = target;
        
    }

    



}
