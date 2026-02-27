using UnityEngine;

public class Crafter : Npc
{
    
    protected override Vector2 GetTargetPosition()
    {
        if (Vector3.Distance(transform.position, workStation.transform.position) < 1)
        {
            Home.instance.CraftSword();
            return home.transform.position;
        }
        if (Home.instance.CanCraft())
        {
            
            return workStation.transform.position;
        }
        return new Vector2(Random.Range(-5f,5f),Random.Range(-2.5f,2.5f));
    }
}
