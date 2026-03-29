using UnityEngine;

[CreateAssetMenu(fileName = "GameParameters", menuName = "Scriptable Objects/GameParameters")]
public class GameParameters : ScriptableObject
{
    // tres bien
    public int numberOfCrafters = 2;
    public int numberOfHarvesters = 5;
    public int numberOfMiners = 5;
    public int numberOfTrees = 10;
    public int numberOfStones = 10;
    
    
    public int woodPrice = 8;
    public int stonePrice = 8;
}
