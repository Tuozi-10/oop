using TMPro;
using UnityEngine;

public class Home : MonoBehaviour
{
    public static Home instance;   
    
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

    
    // les responsabilités sont bonnes, l'update de l'ui est aux bons endroits, c'est vraiment tres bien
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
        woodAvailable -= GameManager.instance.gameParameters.woodPrice;
        stoneAvailable -= GameManager.instance.gameParameters.stonePrice;
    }

    public void TakeWood(Crafter crafter)
    {
        crafter.wood += GameManager.instance.gameParameters.woodPrice;
        wood -= GameManager.instance.gameParameters.woodPrice;
        ReloadText();
    }
    
    public void TakeStone(Crafter crafter)
    {
        crafter.stone += GameManager.instance.gameParameters.stonePrice;
        stone -= GameManager.instance.gameParameters.stonePrice;
        ReloadText();
    }

    public void PoseSword()
    {
        sword += 1;
        ReloadText();
    }
    
    public bool HasEnoughRessources()
    {
        return woodAvailable >= GameManager.instance.gameParameters.woodPrice && stoneAvailable >= GameManager.instance.gameParameters.stonePrice;
    }

    public void ReloadText()
    {
        woodText.text = wood.ToString();
        stoneText.text = stone.ToString();
        swordText.text = sword.ToString();
    }
}
