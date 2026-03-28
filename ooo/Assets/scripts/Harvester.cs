using UnityEngine;

public class Harvester : NPC
{
    public Recoltable.Recoltabletype recoltabletype;

    private bool hasRessources = false;
    
    private Recoltable currentTargetResource;

    // beaucoup trop de choses là dedans, tu as plusieurs possibilités,
    // soit avoir un FixedUpdate dans ta classe mère
    // et avoir une méthode surchargeable pour spécifier le comportement genre "MoveTo"
    // soit à minima avoir une autre fonction pour stocker tout ce code de manière plus explicite
    protected override void FixedUpdate()
    {
        if (!hasRessources)
        {
            if (currentTargetResource is null)
            {
                currentTargetResource = Recoltable.GetClosestRecoltable(recoltabletype, transform.position);
            }

            if (currentTargetResource is not null)
            {
                if (Distanced(currentTargetResource.transform.position))
                {
                    WalkTo(currentTargetResource.transform.position);
                }
                else
                {
                    currentTargetResource.Collect();
                    hasRessources = true;
                    currentTargetResource = null;
                }
            }
        }
        else
        {
            if (House.Instance == null) return;

            if (Distanced(House.Instance.transform.position))
            {
                WalkTo(House.Instance.transform.position);
            }
            else
            {
                House.Instance.DepositResource(recoltabletype);
                hasRessources = false;
            }
        }
    }
}