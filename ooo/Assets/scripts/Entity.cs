using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public abstract class Entity : MonoBehaviour
{
    public Vector2 target = new Vector2();
    public float speed = 0.005f;
    public bool hasRessources = false;
    
    public abstract Vector2 TargetWalkPos();
    
    public void WalkTo(Vector2 pos)
    {
        Vector2 actualPos = transform.position;
        Vector2 vectorToApply = new Vector2();
        vectorToApply.x = (pos.x - actualPos.x);
        vectorToApply.y = (pos.y - actualPos.y);
        vectorToApply.Normalize();
        transform.Translate(vectorToApply * speed);
    }

    public bool CheckDistance(Vector2 pos)
    {
        return Vector2.Distance(pos, transform.position) > 1;
    }
    
    private void FixedUpdate()
    {
        if (CheckDistance(target))
        {
            WalkTo(target);
        }
        else
        {
            target = TargetWalkPos();
        }
    }
}
