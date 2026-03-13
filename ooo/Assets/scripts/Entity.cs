using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected EntityParameters entityParameters;
    [SerializeField] protected GameObject workStation;
    
    [Header("Ressources")]
    public int wood;
    public int stone;
    public int sword;
    
    private Vector2 targetPosition;
    private Vector2 direction;
    protected GameObject home;
    
    protected abstract Vector2 GetTargetPosition();
    
    private void Start()
    {
        home = Home.instance.gameObject;
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
        direction *= entityParameters.speed;
        transform.Translate(direction); 
    }

    private void FixedUpdate()
    {
        Move();
    }
}