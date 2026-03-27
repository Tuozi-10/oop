using System.Resources;
using UnityEngine;

public class StoneFarmer : Farmer
{
    protected override void Deposit()
    {
        ResourceManager.Instance.AddStone(1);
    }
}