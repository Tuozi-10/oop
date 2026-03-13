using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;

public class Collectable : MonoBehaviour, ICollectable
{
    [SerializeField] private float timeDisable;
    [SerializeField] public ressourcesType type;
    public bool isAssigned;
    private SpriteRenderer sprite;
    
    public enum ressourcesType
    {
        wood = 1,
        stone = 2
    }

    private void Awake()
    {
        Harvester.collectable.Add(this);
    }

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    IEnumerator TempDisable()
    {
        sprite.color = new Color(1,1,1,0.5f);
        yield return new WaitForSeconds(timeDisable);
        sprite.color = new Color(1,1,1,1);
        isAssigned = false;
    }

    public ressourcesType Collect()
    {
        StartCoroutine(TempDisable());
        return type;
    }
}
