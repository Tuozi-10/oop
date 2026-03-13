using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Serialization;

public class HarvestManager : MonoBehaviour
{ 
    public static HarvestManager Instance;
    
    [FormerlySerializedAs("_moveSpeed")]
    [Header("Harvesters")]
    [UnityEngine.Range(0f,1f)] public float moveSpeed;
    public Vector2 idleRange;
    public float detectionRadius;
    public int maxCarry;
    
    [Header("Harvestables")]
    public float cooldownTime;
    public List<GameObject> woodList = new List<GameObject>();
    public List<GameObject> rockList = new List<GameObject>();

    public int onHarvestWoodValue;
    public int onHarvestRockValue;
    
    public enum Type
    {
        Wood,
        Rock
    }

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
}
