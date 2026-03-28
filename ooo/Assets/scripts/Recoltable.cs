using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoltable : MonoBehaviour
{
    public static List<Recoltable> allActiveRecoltables = new List<Recoltable>();

    public Recoltabletype recoltabletype;
    [SerializeField] private float respawnTime = 5f;
    
    private Renderer _renderer;

    public enum Recoltabletype
    {
        Rock = 1,
        Tree = 2
    }

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();

        allActiveRecoltables.Add(this);
    }

    public void Collect()
    {
        StartCoroutine(RespawnRoutine());
    }

    // la logique est bonne avec la liste qui s'met à jour, c'est bien
    private IEnumerator RespawnRoutine()
    {
        allActiveRecoltables.Remove(this);

        _renderer.enabled = false;

        yield return new WaitForSeconds(respawnTime);

        _renderer.enabled = true;
        allActiveRecoltables.Add(this);
    }

    public static Recoltable GetClosestRecoltable(Recoltabletype type, Vector2 pos)
    {
        Recoltable closest = null;
        float minDist = Mathf.Infinity;

        foreach (var res in allActiveRecoltables)
        {
            if (res.recoltabletype == type)
            {
                float dist = Vector2.Distance(pos, res.transform.position);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = res;
                }
            }
        }
        return closest;
    }
}