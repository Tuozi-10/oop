using System;
using UnityEngine;
using Random = UnityEngine.Random;

// j'l'aurais appellé Abs_Entité, pour m'assurer que le dev qui dessus en random sache d'office qu'il faut pas l'utiliser mais utiliser ses enfants
public abstract class Entity : MonoBehaviour
{
    [SerializeField] private BonomeDataa data;
    [SerializeField] protected stock stock;
    protected Vector3 targetPosition;
    private Vector3 direction;
    
    
    // si possible garde seulement des appels de fonctions claires dans tes différentes updates, pour éviter des "il fait quoi déja le code là dedans"
    // si t'avais une fonction "moveToTarget" on saurait ce que tu veux faire directement par exemple
    private void FixedUpdate()
    {
        if (Vector3.Distance(targetPosition, transform.position) >0.1)
        {
            direction = (targetPosition - transform.position).normalized;
            transform.Translate(direction.x*data.speed,direction.y*data.speed,0);            
        }
        else
        {
            direction = Vector3.zero;
        }
    }

    // j'aurais ptet appellé CheckDistance par "IsNear" pour rendre ca encore plus compréhensible
    protected bool CheckDistance(Vector3 location)
    {
        if (Vector3.Distance(location, transform.position) < 0.5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    protected void Walk(Vector3 destination)
    {
        targetPosition = destination;
    }
    protected void Walk()
    {
        if (CheckDistance(targetPosition))
        {
            // ptet à rendre serializable pour rendre ca plus modulable
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5.5f, 5.5f), 0);
            targetPosition = randomPosition;
        }
    }





}
    