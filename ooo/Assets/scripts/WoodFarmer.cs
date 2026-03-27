using System.Resources;
using UnityEngine;

public class WoodFarmer : Farmer
{
    protected override void Deposit()
    {
        ResourceManager.Instance.AddWood(1);
    }
}