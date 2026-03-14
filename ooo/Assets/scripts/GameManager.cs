using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    [Header("UIManager")]
    [SerializeField] private TMP_Text woodText;
    [SerializeField] private TMP_Text stoneText;
    [SerializeField] private TMP_Text swordText;
    
    [Header("Targets")]
    [SerializeField] private GameObject house;
    [SerializeField] private GameObject forge;

    [Header("Ressources")]
    public int wood;
    public int stone;
    public int sword;

    private void Update()
    {
        CollisionDetector();

        woodText.text = "Bois : " + wood;
        stoneText.text = "Pierre : " + stone;
        swordText.text = "Epee : " + sword;
    }

    public void CollisionDetector()
    {
        foreach (var harvester in Harvester.listHarvester)
        {
            if (Vector2.Distance(harvester.transform.position, house.transform.position) <= 1 && harvester.hasRessources)
            {
                harvester.hasRessources = false;
                switch (harvester.myType)
                {
                    case Recoltable.Type.Wood:
                        wood++;
                        break;
                    case Recoltable.Type.Stone:
                        stone++;
                        break;
                }
            }
        }

        foreach (var npc in NPC.listNPC )
        {
            if (Vector2.Distance(npc.transform.position, forge.transform.position) <= 1 && npc.canForge)
            {
                npc.canForge = false;
                npc.hasRessources = true;
            }
            
            if (Vector2.Distance(npc.transform.position, house.transform.position) <= 1 && npc.hasRessources)
            {
                npc.hasRessources = false;
                sword++;
            }
        }
    }
}
