using System;
using UnityEngine;

[SelectionBase]
public class Harvestable : MonoBehaviour
{
    public ObjectType type;

    private void Start()
    {
        GameManager.harvestables.Add(this);
    }
}
