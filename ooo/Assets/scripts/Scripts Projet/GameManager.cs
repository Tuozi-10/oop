using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Ressource ressourceData;
    public static GameManager instance;
    [SerializeField] TextMeshProUGUI ressourceTextBois;
    [SerializeField] TextMeshProUGUI ressourceTextPierre;
    [SerializeField] TextMeshProUGUI ressourceTextOutils;
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
            ressourceTextBois.text = "Bois : " + bois.ToString();
        }
        else if (ressource == 2)
        {
            pierre+= 10;
            Debug.Log(pierre);
            ressourceTextPierre.text = "Pierre : " + pierre.ToString();
        }
        else if (ressource == 3)
        {
            outils++;
            Debug.Log(outils);
            ressourceTextOutils.text = "Outils : " + outils.ToString();
        }
        else
        {
            Debug.Log("svp ressource");
        }
    }
}
