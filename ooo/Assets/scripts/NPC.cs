using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Entity
{
    private Vector2 RandomWalk()
    {
        Vector2 walkPos = new Vector2();
        walkPos.x = Random.Range(-10, 10);
        walkPos.y = Random.Range(-10, 10);
        return walkPos;
    }
    
    protected virtual void FixedUpdate()
    {
        if (Distanced(target))
        {
            WalkTo(target);
        }
        else
        {
            target = RandomWalk();
        }
    }
}