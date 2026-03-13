using System;
using System.Collections;
using UnityEngine;
using static HarvestManager.Type;

public class Harvestable : MonoBehaviour
{
    [SerializeField] private HarvestManager.Type harvestableType;
    private SpriteRenderer spriteRenderer;
    private int onHarvestValue;
    public bool activated = true;


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        switch (harvestableType)
        {
            case Rock:
                onHarvestValue = HarvestManager.Instance.onHarvestRockValue;
                HarvestManager.Instance.rockList.Add(gameObject);
                break;
            case Wood:
                onHarvestValue = HarvestManager.Instance.onHarvestWoodValue;
                HarvestManager.Instance.woodList.Add(gameObject);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public IEnumerator DesActivate()
    {
        activated = false;
        spriteRenderer.color = Color.grey;
        
        yield return HarvestManager.Instance.cooldownTime;
        ReActivate();
    }

    private void ReActivate()
    {
        activated = true;
        spriteRenderer.color = Color.white;
    }
}
