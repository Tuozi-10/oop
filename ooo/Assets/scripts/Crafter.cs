using UnityEngine;

public class Crafter : Npc
{
    public bool hasReservedRessources;
    
    protected override Vector2 GetTargetPosition()
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
        if (Vector3.Distance(transform.position, workStation.transform.position) < 1 && HasEnoughRessources())
        {
            Home.instance.CraftSword(this);
            return home.transform.position;
        }
        if (HasEnoughRessources())
        {
            return workStation.transform.position;
        }
        if (Home.instance.HasEnoughRessources())
        {
            Home.instance.ReserveRessources();
            hasReservedRessources = true;
            return home.transform.position;
        }
        return new Vector2(Random.Range(-5f, 5f),Random.Range(-2.5f, 2.5f));
    }

    private bool HasEnoughRessources()
    {
        return wood >= Home.instance.woodPrice && stone >= Home.instance.stonePrice;
    }
}
