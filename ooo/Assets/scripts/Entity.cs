using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private BonomeDataa data;
    [SerializeField] protected stock stock;
    protected Vector3 targetPosition;
    private Vector3 direction;
    
    
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
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-5.5f, 5.5f), 0);
            targetPosition = randomPosition;
        }
    }





}
    