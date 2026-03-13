using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Recoltable : MonoBehaviour
{
    private static List<Recoltable> allRecoltable = new List<Recoltable>();

    [SerializeField] private Recoltabletype recoltabletype;
    public enum Recoltabletype
    {
        Rock = 1,
        Tree = 2
    }

    public void Awake()
    {
        allRecoltable.Add(this);
    }
 
    public static Recoltable GetClosestRecoltable(Recoltabletype recoltableType, Vector2 harvesterPos)
    {
        var closestRecoltable = allRecoltable[0];
        foreach (var Recoltable in allRecoltable)
        {
            if (Vector2.Distance(harvesterPos, Recoltable.transform.position) < Vector2.Distance(harvesterPos, closestRecoltable.transform.position))
            {
                closestRecoltable = Recoltable;
            }
        }

        return closestRecoltable; 
    }

}
