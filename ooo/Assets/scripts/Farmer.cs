using UnityEngine;

public abstract class Farmer : MonoBehaviour
{
    public Transform house;
    public Transform resource;

    protected float speed = 2f;

    protected bool goingToResource = true;

    void Update()
    {
        if (goingToResource)
        {
            Move(resource.position);

            if (Vector2.Distance(transform.position, resource.position) < 0.1f)
            {
                goingToResource = false;
            }
        }
        else
        {
            Move(house.position);

            if (Vector2.Distance(transform.position, house.position) < 0.1f)
            {
                Deposit();
                goingToResource = true;
            }
        }
    }

    protected virtual void Move(Vector2 target)
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target,
            speed * Time.deltaTime
        );
    }

    protected abstract void Deposit();
}