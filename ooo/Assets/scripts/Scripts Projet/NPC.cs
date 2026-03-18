using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Entity1
{
    public Vector2 posInit = new Vector2();
    public Vector2 targetPos = new Vector2();
    public bool moveEnd = false;
    
    public NPC()
    {
    }

    private void Start()
    {
        posInit = transform.position;
        targetPos = RandomCoords();
        //Debug.Log(targetPos); 
    }
    

    public Vector3 RandomCoords()
    {
        float moveX = Random.Range(-8, 8);
        float moveY = Random.Range(-4, 4);
        Vector3 _targetPos = new Vector3(moveX, moveY, 0);
        //Debug.Log("targetPos:" + _targetPos);
        
        return _targetPos;
    }
    

    public virtual void Move()
    {
        if (Vector3.Distance(targetPos, transform.position) < 0.1)
        {
            moveEnd = true;
            //Debug.Log("Bien arrivé à " + targetPos);
            posInit = transform.position;
            targetPos = RandomCoords();
            moveEnd = false;
        }
        else
        {
            transform.Translate( new Vector3(targetPos.x - posInit.x,targetPos.y - posInit.y).normalized * speed);
        }
        
    }

    private void FixedUpdate()
    {
        if (moveEnd == false)
        {
            Move();
        }
    }
}
