using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject home;
    [SerializeField] private GameObject forge;
    [SerializeField] private GameObject localBucheron;
    [SerializeField] private GameObject localMineur;
    [SerializeField] private GameObject forest;
    [SerializeField] private GameObject mine;
    
    [SerializeField] private GameObject crafterPrefab;
    [SerializeField] private GameObject bucheronPrefab;
    [SerializeField] private GameObject minerPrefab;

    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject stonePrefab;
    
    [SerializeField] private GameSettings gameSettings;
    
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this); }
    }

    private void Start()
    {
        InstantiateEntity();
        InstantiateCollectable();
    }

    private void InstantiateEntity()
    {
        for (int i = 0; i < gameSettings.numberOfCrafter; i++)
        {
            GameObject crafter = Instantiate(crafterPrefab, forge.transform.position, Quaternion.identity);
            crafter.GetComponent<Crafter>().workStation = forge;
        }
        
        for (int i = 0; i < gameSettings.numberOfHarvester; i++)
        {
            GameObject harvester = Instantiate(bucheronPrefab, localBucheron.transform.position, Quaternion.identity);
            harvester.GetComponent<Harvester>().workStation = localBucheron;
        }
        
        for (int i = 0; i < gameSettings.numberOfMiner; i++)
        {
            GameObject miner = Instantiate(minerPrefab, localMineur.transform.position, Quaternion.identity);
            miner.GetComponent<Harvester>().workStation = localMineur;
        }
    }
    
    private void InstantiateCollectable()
    {
        for (int i = 0; i < gameSettings.numberOfTree; i++)
        {
            Vector3 randomPosition = new(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            Instantiate(treePrefab, forest.transform.position + randomPosition, Quaternion.identity);
        }
        
        for (int i = 0; i < gameSettings.numberOfTree; i++)
        {
            Vector3 randomPosition = new(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
            Instantiate(stonePrefab, mine.transform.position + randomPosition, Quaternion.identity);
        }
    }
}
