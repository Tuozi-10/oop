using System.Collections.Generic;
using UnityEngine;

public class Recoltable : MonoBehaviour
{
    
    public static List<Recoltable> recoltables = new List<Recoltable>();
    
    public Recolt recolt;
    public static int boisInitial;
    public static int pierreInitial;

    public void Awake()
    {
        recoltables.Add(this);
    }

    public void Start()
    {
        if(recolt == Recolt.arbre)
        {
            boisInitial = 500;
        }
        if(recolt == Recolt.pierre)
        {
            pierreInitial = 500;
        }
    }
    
}
