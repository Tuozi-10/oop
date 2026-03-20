using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Ressource ressourceData;
    [SerializeField] public TextMeshProUGUI ressourceTextBois;
    [SerializeField] public TextMeshProUGUI ressourceTextPierre;
    [SerializeField] public TextMeshProUGUI ressourceTextOutils;
    public int bois;
    public int pierre;
    public int outils;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }
    }
    
    void Start()
    {
        
        bois = ressourceData.bois;
        pierre = ressourceData.pierre;
        outils = ressourceData.outils;
    }

    public void IncrementRessource(int ressource)
    {
        if (ressource == 1)
        {
            bois+= 10;
            Debug.Log(bois);
        }
        else if (ressource == 2)
        {
            pierre+= 10;
            Debug.Log(pierre);
        }
        else if (ressource == 3)
        {
            outils++;
            Debug.Log(outils);
        }
        else
        {
            Debug.Log("svp ressource");
        }
        ressourceTextBois.text = "Bois : " + bois.ToString();
        ressourceTextPierre.text = "Pierre : " + pierre.ToString();
        ressourceTextOutils.text = "Outils : " + outils.ToString();
    }
}
