using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Entity : MonoBehaviour
{                                                           
    protected float _moveSpeed;
    protected Vector2 _maxIdleRange;
    protected Vector2 _minIdleRange;
    protected float _detectionRadius;
    
    protected bool hasGameObjectAsTarget;
    protected GameObject targetGameObject;
    protected Vector3 targetPos = new Vector3();

    private Vector3 _lastFramePos;

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
        
        MoveTowardsTargetPos();
        Flip();
    }

    private void LateUpdate()
    {
        _lastFramePos = transform.position;
    }

    protected virtual void Interact(GameObject gameObject)
    {
        throw new NotImplementedException();
    }
    
    protected virtual void SetRandomTargetPos()
    {
        var randomX = Random.Range(_minIdleRange.x, _maxIdleRange.x);
        var randomY = Random.Range(_minIdleRange.y, _maxIdleRange.y);

        targetPos = new Vector2(randomX, randomY);
    }

    private void MoveTowardsTargetPos()
    {
        var direction =  (targetPos - transform.position).normalized;
        transform.position += direction * _moveSpeed;
    }

    private void Flip()
    {
        if (_lastFramePos.x - transform.position.x < 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
