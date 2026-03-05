using System;
using System.Collections;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float timeDisable;
    [SerializeField] private ressourcesType type;
    public bool isAvailable = true;
    public bool isAssigned = false;
    private SpriteRenderer sprite;
    
    public enum ressourcesType
    {
        wood = 1,
        stone = 2
    }

    private void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    IEnumerator TempDisable()
    {
        isAvailable = false;
        sprite.color = new Color(1,1,1,0.5f);
        yield return new WaitForSeconds(timeDisable);
        sprite.color = new Color(1,1,1,1);
        isAssigned = false;
        isAvailable = true;
    }


    public ressourcesType Collect()
    {
        StartCoroutine(TempDisable());
        return type;
    }
    
}
