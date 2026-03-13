using System;
using UnityEngine;

public class Harvester : Npc
{
    [SerializeField] private Collectable[] collectable;
    private Collectable currentCollectable;
    private int ressourcesCapacity = 2;


    protected override Vector2 GetTargetPosition()
    {

        if (Vector2.Distance(transform.position, home.transform.position) < 1f)
        {
            Home.instance.PoseWood(wood);
            wood = 0;
            Home.instance.PoseStone(stone);
            stone = 0;
            return workStation.transform.position;
        }
        
        if (wood + stone >= ressourcesCapacity)
        {
            return home.transform.position;
        }
        
        if (Vector2.Distance(transform.position, workStation.transform.position) < 1f)
        {
            for (int i = 0; i < collectable.Length; i++)
            {
                if (!collectable[i].isAssigned)
                {
                    currentCollectable = collectable[i];
                    currentCollectable.isAssigned = true;
                    return currentCollectable.gameObject.transform.position;
                }
            }
        }
        
        if (currentCollectable != null && Vector2.Distance(transform.position, currentCollectable.gameObject.transform.position) < 1f)
        {
            Collectable.ressourcesType collectType = currentCollectable.Collect();
            if (collectType == Collectable.ressourcesType.wood)
            {
                wood += 1;
            }
            else if (collectType == Collectable.ressourcesType.stone)
            {
                stone += 1;
            }

            return workStation.transform.position;
        }
        
        return home.transform.position;
    }
}
