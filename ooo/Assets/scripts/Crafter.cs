using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Crafter : Entity
{
    [Header("Crafter Parameters")]
    [SerializeField] private GameParameters gameParameters;
    public bool hasReservedRessources;

    [Header("Preferences")]
    private Forge forgeScript;

    protected override void OnStart()
    {
        forgeScript = workStation.GetComponent<Forge>();
    }

    protected override Vector2 GetTargetPosition()
    {
        CloseHome();
        
        if (Vector3.Distance(transform.position, workStation.transform.position) < 1 && HasEnoughRessources()) { return Crafting(); }
        
        if (HasEnoughRessources()) { return workStation.transform.position; }
        
        if (Home.instance.HasEnoughRessources()) { return EnoughRessources(); }
        
        return new Vector2(Random.Range(-5f, 5f),Random.Range(-2.5f, 2.5f));
    }

    private bool HasEnoughRessources()
    {
        return wood >= gameParameters.woodPrice && stone >= gameParameters.stonePrice;
    }
    
    private void CloseHome()
    {
        if (Vector3.Distance(transform.position, home.transform.position) < 1)
        {
            if (sword != 0)
            {
                Home.instance.PoseSword();
                sword -= 1;
            }

            if (hasReservedRessources)
            {
                Home.instance.TakeWood(this);
                Home.instance.TakeStone(this);
                hasReservedRessources = false;
            }
        }
    }

    private Vector3 EnoughRessources()
    {
        Home.instance.ReserveRessources();
        hasReservedRessources = true;
        return home.transform.position;
    }

    private Vector3 Crafting()
    {
        forgeScript.CraftSword(this);
        return home.transform.position;
    }
}
