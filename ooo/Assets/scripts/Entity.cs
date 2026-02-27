using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public float speed;
    private Vector2 targetPosition;
    private Vector2 direction;
    private Rigidbody2D rb;
    protected abstract Vector2 GetTargetPosition();

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        targetPosition = GetTargetPosition();
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position,targetPosition) < 1)
        {
            targetPosition = GetTargetPosition();
        }
        direction =  targetPosition - new Vector2(transform.position.x,transform.position.y);
        direction.Normalize();
        direction *= speed;
        transform.Translate(direction);
    }

    private void FixedUpdate()
    {
        Move();
    }
}