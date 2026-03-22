using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // j'te conseille de prendre le reflexe de dev et nommer en anglais, plus vite tu prends le pli moins ca sera dur à la sortie de l'école
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

    // pense à clean tes debug log quand tu as fini de debug, ca t'évite de perdre des perfs ( ils sont assez couteux si spammés )
    public void IncrementRessource(int ressource)
    {
        if (ressource == 1)
        {
            // pas hyper évolutif la variable en dur, hésite pas à utiliser des serialize, des scriptables, ou à minima des constantes
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
