using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameParameters gameParameters;

    [Header("Prefabs")]
    [SerializeField] private GameObject crafterPrefab;
    [SerializeField] private GameObject harvesterPrefab;
    [SerializeField] private GameObject minerPrefab;
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject stonePrefab;
    
    [Header("Spawn Point")]
    [SerializeField] private GameObject forge;
    [SerializeField] private GameObject localBucheron;
    [SerializeField] private GameObject localMiner;
    [SerializeField] private GameObject forest;
    [SerializeField] private GameObject mine;
    
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this); }
        
        InitialiseRessources();
        InitialiseEntity();
    }

    private void InitialiseEntity()
    {
        for (int i = 0; i < gameParameters.numberOfCrafters; i++)
        {
            GameObject entity = Instantiate(crafterPrefab, forge.transform.position, Quaternion.identity);
            entity.GetComponent<Crafter>().workStation = forge;
        }
        for (int i = 0; i < gameParameters.numberOfHarvesters; i++)
        {
            GameObject entity = Instantiate(harvesterPrefab, localBucheron.transform.position, Quaternion.identity);
            entity.GetComponent<Harvester>().workStation = localBucheron;
        }
        for (int i = 0; i < gameParameters.numberOfMiners; i++)
        {
            GameObject entity = Instantiate(minerPrefab, localMiner.transform.position, Quaternion.identity);
            entity.GetComponent<Harvester>().workStation = localMiner;
        }
    }
    
    private void InitialiseRessources()
    {
        for (int i = 0; i < gameParameters.numberOfTrees; i++)
        {
            Vector3 randomPosition = new(Random.Range(-2f,2f),Random.Range(-2f,2f),Random.Range(-2f,2f));
            Instantiate(treePrefab, forest.transform.position + randomPosition, Quaternion.identity);
        }
        for (int i = 0; i < gameParameters.numberOfStones; i++)
        {
            Vector3 randomPosition = new(Random.Range(-2f,2f),Random.Range(-2f,2f),Random.Range(-2f,2f));
            Instantiate(stonePrefab, mine.transform.position + randomPosition, Quaternion.identity);
        }
    }
}
