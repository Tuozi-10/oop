using UnityEngine;

public class House : MonoBehaviour
{
    public static House Instance;
    
    public int woodCount = 0;
    public int stoneCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    
    public void DepositResource(Recoltable.Recoltabletype type)
    {
        if (type == Recoltable.Recoltabletype.Tree)
        {
            woodCount++;
        }
        else if (type == Recoltable.Recoltabletype.Rock)
        {
            stoneCount++;
        }
    }
}