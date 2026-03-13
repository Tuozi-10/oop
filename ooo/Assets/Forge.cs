using UnityEngine;

public class Forge : MonoBehaviour
{
    public void CraftSword(Crafter crafter)
    {
        crafter.wood -= GameManager.instance.gameParameters.woodPrice;
        crafter.stone -= GameManager.instance.gameParameters.stonePrice;
        crafter.sword += 1;
    }
}
