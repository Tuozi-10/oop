using UnityEngine;
 
public class GameManager : MonoBehaviour
{
    public GameObject harvesterPrefab;
 
    public int harvesterCount = 3;
 
    public Vector2 spawnArea = new Vector2(3f, 3f);
 
    private void Start()
    {
        SpawnHarvesters();
    }
 
    private void SpawnHarvesters()
    {
        if (harvesterPrefab == null)
        {
            return;
        }
 
        for (int i = 0; i < harvesterCount; i++)
        {
            Vector2 spawnPos = (Vector2)transform.position + new Vector2(
                Random.Range(-spawnArea.x, spawnArea.x),
                Random.Range(-spawnArea.y, spawnArea.y)
            );
 
            Instantiate(harvesterPrefab, spawnPos, Quaternion.identity);
        }
    }
}