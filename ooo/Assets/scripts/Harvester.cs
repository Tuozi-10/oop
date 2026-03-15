using UnityEngine;

public class Harvester : NPC
{
    public Recoltable.Recoltabletype recoltabletype;

    private bool hasRessources = false;
    private Recoltable currentTargetResource;

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