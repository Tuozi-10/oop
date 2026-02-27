using UnityEngine;

public abstract class Npc : Entity
{
    [SerializeField] protected GameObject workStation;

    protected GameObject home;
    
    private void Start()
    {
        home = Home.instance.gameObject;
    }
}
