using UnityEngine;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public int wood;
    public int stone;

    public TextMeshProUGUI text;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        text.text = "Bois: " + wood + "  Pierre: " + stone;
    }

    public void AddWood(int amount)
    {
        wood += amount;
    }

    public void AddStone(int amount)
    {
        stone += amount;
    }
}