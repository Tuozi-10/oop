using System.Collections.Generic;
using UnityEngine;

public class Harvester : Entity
{
    [Header("Harvester Parameters")]
    [SerializeField] private HarvesterParameters harvesterParameters;
    public static List<Collectable> collectable = new ();
    public Collectable.ressourcesType typeOfRessources;
    public Collectable currentCollectable;

    protected override Vector2 GetTargetPosition()
    {
        if (Distance(transform, home) < 1f) { return NearHouse(); }
        
        if (wood + stone >= harvesterParameters.ressourcesCapacity) { return home.transform.position; }
        
        if (Distance(transform.position, workStation) < 1f) { return FindRessourcesAvailable(); }
        
        if (currentCollectable != null && Distance(transform.position, currentCollectable.gameObject) < 1f) { return NearRessources(); }
        
        return home.transform.position;
    }

    private Vector3 NearHouse()
    {
        Home.instance.PoseWood(wood);
        wood = 0;
        Home.instance.PoseStone(stone);
        stone = 0;
        return workStation.transform.position;
    }

    private Vector3 FindRessourcesAvailable()
    {
        for (int i = 0; i < collectable.Count; i++)
        {
            if (!collectable[i].isAssigned && collectable[i].type == typeOfRessources)
            {
                currentCollectable = collectable[i];
                currentCollectable.isAssigned = true;
                return currentCollectable.gameObject.transform.position;
            }
        }
        return home.transform.position;
    }

    private Vector3 NearRessources()
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

    private float Distance(Transform elementTransform, GameObject otherElement)
    {
        return Vector2.Distance(elementTransform.position, otherElement.transform.position);
    }
    
    private float Distance(Vector3 position, GameObject element)
    {
        return Vector2.Distance(position, element.transform.position);
    }
}
