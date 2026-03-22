using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoltable : MonoBehaviour
{
    
    public RecoltableType recoltableType;
    public bool isEnabled = true;
    public bool isChosen;
    public enum RecoltableType
    {
        bois,
        pierre
    }
    
    private void Awake()
    {
        Harvester.recoltableList.Add(this);
    }
    
    public void DisableRecoltable()
    {
        StartCoroutine(Disable());
    }
    public IEnumerator Disable()
    {
        // pas oufito les appels régulires à des get component, essaies de les garder en cache le plus possible
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 0.5f);
        isEnabled = false;
        yield return new WaitForSeconds(5.0f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 1f);
        isEnabled = true;
        //isChosen = false;
    }
    
    
    
}
