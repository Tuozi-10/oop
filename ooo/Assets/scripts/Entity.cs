using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected float speed = 0.05f;
    protected Vector3 targetPosition;
    private Vector3 direction;
    
    
    private void FixedUpdate()
    {
        if (Vector3.Distance(targetPosition, transform.position) >0.1)
        {
            direction = (targetPosition - transform.position).normalized;
            transform.Translate(direction.x*speed,direction.y*speed,0);            
        }
        else
        {
            direction = Vector3.zero;
        }
    }




}
    