using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Scriptable Objects/GameSettings")]
public class GameSettings : ScriptableObject
{
    public int numberOfCrafter;
    public int numberOfHarvester;
    public int numberOfMiner;
    public int numberOfTree;
    public int numberOfStone;
}
