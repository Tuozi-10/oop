using TMPro;
using UnityEngine;

public class Home : MonoBehaviour
{
    public static Home instance;   
    
    [Header("Parameters")]
    [SerializeField] private GameParameters gameParameters;
    
    [Header("Text Reference")]
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text stoneText;
    [SerializeField] private TMP_Text swordText;

    [Header("Ressources")]
    public int wood;
    public int stone;
    public int sword;
    
    [Header("Ressources Available")]
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

    public void PoseWood(int ressources)
    {
        wood += ressources;
        woodAvailable += ressources;
        ReloadText();
    }
    
    public void PoseStone(int ressources)
    {
        stone += ressources;
        stoneAvailable += ressources;
        ReloadText();
    }

    public void ReserveRessources()
    {
        woodAvailable -= gameParameters.woodPrice;
        stoneAvailable -= gameParameters.stonePrice;
    }

    public void TakeWood(Crafter crafter)
    {
        crafter.wood += gameParameters.woodPrice;
        wood -= gameParameters.woodPrice;
        ReloadText();
    }
    
    public void TakeStone(Crafter crafter)
    {
        crafter.stone += gameParameters.stonePrice;
        stone -= gameParameters.stonePrice;
        ReloadText();
    }

    public void PoseSword()
    {
        sword += 1;
        ReloadText();
    }
    
    public void CraftSword(Crafter crafter)
    {
        crafter.wood -= gameParameters.woodPrice;
        crafter.stone -= gameParameters.stonePrice;
        crafter.sword += 1;
        ReloadText();
    }

    public bool HasEnoughRessources()
    {
        return woodAvailable >= gameParameters.woodPrice && stoneAvailable >= gameParameters.stonePrice;
    }

    private void ReloadText()
    {
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        swordText.text = sword.ToString();
    }
}
