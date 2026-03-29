using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoltable : MonoBehaviour
{
    public static List<Recoltable> listRecoltables = new List<Recoltable>();
    
    // pas giga explicite Type et myType, hésite aps à le rendre un poil plus explicite ( harvestableType par exemple )
    public enum Type
    {
        Wood,
        Stone,
        Sword
    }

    [SerializeField] private Type myType;

    private bool isActive = true;

    private void Awake()
    {
        listRecoltables.Add(this);
    }

    private void Update()
    {
        CollisionHarvester();
    }

    public static Recoltable closestRecoltable(Type recoltableType, Vector2 posHarvester)
    {
        Recoltable recoltableToHarvest = null;
        
        foreach (var recoltable in listRecoltables)
        {
            if (recoltable.isActive == false)
            {
                continue;
            }

            if (recoltable.myType == recoltableType)
            {
                if (recoltableToHarvest == null )
                {
                    recoltableToHarvest = recoltable;
                }
                else if (Vector2.Distance(recoltableToHarvest.transform.position, posHarvester) >= Vector2.Distance(recoltable.transform.position, posHarvester))
                {
                    recoltableToHarvest = recoltable;
                }
            }
        }
        return recoltableToHarvest;
    }

    // j'trouve ca conceptuellement weird d'avoir le recoltable qui check si le récolteur peut le choper, j'aurais plus vu
    // dans le récolteur la logique de "est ce que je suis dans la zone de ce que je veux récolter"
    // et en bonus, tu pourrais avoir un récolteur d'un autre type qui passe proche de ta ressource,
    // et paf elle décide de lui sauter dans les mains parce que passé trop proche d'un arbre alors qu'il voulait un caillou
    // OU PIRE, il pourrait avoir déjà une ressource, et ca ca le faire récolter en double
    // OU PIIIIIRE, il chope un caillou, il passe proche d'un arbre, l'arbre est du coup récolté,
    // mais quand le mineur va passer à ta maison, y'aura bien le caillou mais pas l'arbre de livré
    // OU PIRRRRREEE, ouais nan rien d'autre de pire, c'est déjà caca
    public void CollisionHarvester()
    {
        foreach (var harvester in Harvester.listHarvester)
        {
            if (Vector2.Distance(harvester.transform.position, transform.position) <= 1 && isActive)
            {
                harvester.hasRessources = true;
                ChangeState();
                break;
            }
        }
    }
    
    private void ChangeState()
    {
        isActive = !isActive;
        if (isActive == false)
        {
            StartCoroutine(WaitSetActive());
            
        }
    }

    private IEnumerator WaitSetActive()
    {
        yield return new WaitForSeconds(7.5f);
        ChangeState();
    }
}
