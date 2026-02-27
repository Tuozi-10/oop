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
        wood += 1;
        ReloadText();
    }
    
    public void AddStone()
    {
        stone += 1;
        ReloadText();
    }
    
    public void CraftSword()
    {
        wood -= woodPrice;
        stone -= stonePrice;
        sword += 1;
        ReloadText();
    }

    public bool CanCraft()
    {
        return wood >= woodPrice && stone <= stonePrice;
    }

    public void ReloadText()
    {
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        swordText.text = sword.ToString();
    }
}
