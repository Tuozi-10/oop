using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Entity : MonoBehaviour
{                                                           
    protected float _moveSpeed;
    protected Vector2 _idleRange;
    protected float _detectionRadius;
    
    protected bool hasGameObjectAsTarget;
    protected GameObject targetGameObject;
    protected Vector3 targetPos = new Vector3();

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position,
                targetPos) < _detectionRadius)
        {
            if (!hasGameObjectAsTarget)
            {
                SetRandomTargetPos();
            }
            else
            {
                Interact(targetGameObject);
            }
        }
        
        MoveTowardsTarget();    
    }
    
    protected virtual void Interact(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
    
    private void SetRandomTargetPos()
    {
        var rndmX = Random.Range(-_idleRange.x, _idleRange.x);
        var rndmY = Random.Range(-_idleRange.y, _idleRange.y);

        targetPos = new Vector2(rndmX, rndmY);
    }

    private void MoveTowardsTarget()
    {
        var direction =  (targetPos - transform.position).normalized;
        transform.position += direction * _moveSpeed;
    }
}
