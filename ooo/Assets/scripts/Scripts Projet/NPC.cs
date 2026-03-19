using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Entity1
{
    public Vector2 posInit = new Vector2();
    public Vector2 targetPos = new Vector2();
    public bool moveEnd = false;
    public bool estNPC = true;
    private bool onWork = false;
    private GameObject Forge;
    private bool mouvement = true;

    IEnumerator WorkTime()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.outils++;
        posInit = transform.position;
        targetPos = posMaison;
        mouvement = true;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("NPC"), LayerMask.NameToLayer("Forge"), true);
        Debug.Log(targetPos);
    }
    
    private void Start()
    {
        posInit = transform.position;
        targetPos = RandomCoords();
        Forge = GameObject.FindGameObjectWithTag("Forge");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("NPC"), LayerMask.NameToLayer("Forge"), true);
        //Debug.Log(targetPos); 
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Forge" && onWork == true)
        {
            mouvement = false;
            StartCoroutine(WorkTime());
        }
        else if (other.gameObject.tag == "Forge" && onWork == false)
        {
            targetPos = RandomCoords();
        }
    }

    public Vector3 RandomCoords()
    {
        float moveX = Random.Range(-8, 8);
        float moveY = Random.Range(-4, 4);
        Vector3 _targetPos = new Vector3(moveX, moveY, 0);
        
        return _targetPos;
    }

    private void GoToWork()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("NPC"), LayerMask.NameToLayer("Forge"), false);
        posInit = transform.position;
        targetPos = Forge.transform.position;
    }
    
    
    public virtual void Move()
    {
        if (Vector3.Distance(targetPos, transform.position) < 0.1)
        {
            moveEnd = true;
            posInit = transform.position;
            moveEnd = false;
            if (estNPC == true && onWork == false)
            {
                targetPos = RandomCoords();
            }
        }
        else
        {
            transform.Translate( new Vector3(targetPos.x - posInit.x,targetPos.y - posInit.y).normalized * speed);
        }
        
    }

    private void FixedUpdate()
    {
        if (mouvement == true)
        {
            if (moveEnd == false)
            {
                Move();
            }
            if (GameManager.instance.bois >= 10 && GameManager.instance.pierre >= 10 && onWork == false)
            {
                GoToWork();
                onWork = true;
            }
        }

    }
}
