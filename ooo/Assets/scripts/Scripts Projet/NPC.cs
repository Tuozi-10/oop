using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Entity1
{
    private Vector2 posInit = new Vector2();
    private Vector2 targetPos = new Vector2();
    private bool moveEnd = false;
    public NPC()
    {
        posInit = transform.position;
        //ebug.Log("posInit" + posInit);
        targetPos = RandomCoords();
        Debug.Log(targetPos);
    }

    public Vector2 RandomCoords()
    {
        float moveX = Random.Range(-8, 8);
        float moveY = Random.Range(-4, 4);
        Vector2 _targetPos = new Vector2(moveX,moveY);
        Debug.Log("targetPos:" + _targetPos);
        
        return _targetPos;
    }

    public void Move()
    {
        //Debug.Log(targetPos);
        if (Vector3.Distance(targetPos, transform.position) < 1)
        {
            moveEnd = true;
            targetPos = RandomCoords();
            moveEnd = false;
        }
        else
        {
            transform.Translate( new Vector3(targetPos.x - posInit.x,targetPos.y - posInit.y).normalized * speed);
        }

        Debug.Log(transform.position);
        //Debug.Log(targetPos);
    }

    private void FixedUpdate()
    {
        if (moveEnd == false)
        {
            Move();
        }
    }
}
