
using UnityEngine;

public class Entity : MonoBehaviour
{

    public float speed = 0.01f;

    protected void MoveTo(Vector2 target)
    {
        var direction = target - new Vector2(transform.position.x,transform.position.y);
        direction.Normalize();
        direction *= speed;
        transform.Translate(direction);
    }

    private void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate(){}

}
