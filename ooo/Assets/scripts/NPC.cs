using UnityEngine;
using UnityEngine.PlayerLoop;

public class NPC : Entity
{
    private float wanderLimit = 8f;
    private Vector2 targetPosition;
    
    private void Move(Vector2 randomMovement)
    {
        randomMovement = new Vector2(Random.Range(1, 9), Random.Range(1, 9)); 
        transform.position = randomMovement * Entity.speed;
    }
    
    
    
}
