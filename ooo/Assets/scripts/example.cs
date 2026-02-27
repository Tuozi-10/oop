/*using UnityEngine;




public abstract class Entity : MonoBehaviour
{
    public int pv = 5;

    protected abstract void Die();

    public void Move(int x, int y)
    {
        transform.position = new Vector3(x, y);
    }

    public void Move(Vector2 pos)
    {
        transform.position = pos;
    }
    
    public virtual void TakeDamage(int damage)
    {
        pv -= damage;
        if (pv < 0)
        {
            Die();   
        }
    }
}

public class Player : Entity
{
    protected override void Die()
    {
        
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        Debug.Log("player");
    }
}

public class Monster : fEntity
{
    protected override void Die()
    {
        
    }
}



public class CacaManager
{
    private Player player;
    private Monster mob;
    void Play()
    {
        player.TakeDamage(10);
        mob.TakeDamage(10);
        
        player.Move(10,50);
        player.Move(new Vector2(10,50));
    }
}*/