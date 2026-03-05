using System;
using TMPro;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text stoneText;
    [SerializeField] private TMP_Text swordText;

    public static Home instance;
    public int wood;
    public int stone;
    public int sword;
    public int woodPrice = 8;
    public int stonePrice = 8;
    public int woodAvailable;
    public int stoneAvailable;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }

    private void Start()
    {
        ReloadText();
    }

    public void AddWood()
    {
        wood += 8;
        woodAvailable += 8;
        ReloadText();
    }
    
    public void AddStone()
    {
        stone += 8;
        stoneAvailable += 8;
        ReloadText();
    }

    public void ReserveRessources()
    {
        woodAvailable -= woodPrice;
        stoneAvailable -= stonePrice;
    }

    public void TakeWood(Crafter crafter)
    {
        crafter.wood += woodPrice;
        wood -= woodPrice;
        ReloadText();
    }
    
    public void TakeStone(Crafter crafter)
    {
        crafter.stone += stonePrice;
        stone -= stonePrice;
        ReloadText();
    }

    public void PoseSword(Crafter crafter)
    {
        crafter.sword -= 1;
        sword += 1;
        ReloadText();
    }
    
    public void CraftSword(Crafter crafter)
    {
        crafter.wood -= woodPrice;
        crafter.stone -= stonePrice;
        crafter.sword += 1;
        ReloadText();
    }

    public bool HasEnoughRessources()
    {
        return woodAvailable >= woodPrice && stoneAvailable <= stonePrice;
    }

    public void ReloadText()
    {
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        swordText.text = sword.ToString();
    }
}
