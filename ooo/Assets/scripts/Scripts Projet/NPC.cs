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
        posInit = transform.position;
        targetPos = posMaison;
        mouvement = true;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("NPC"), LayerMask.NameToLayer("Forge"), true);
        Debug.Log(targetPos);
    }

    IEnumerator outilsInMaison()
    {
        mouvement = false;
        yield return new WaitForSeconds(3f);
        GameManager.instance.outils++;
        GameManager.instance.bois -= 10;
        GameManager.instance.pierre -= 10;
        GameManager.instance.ressourceTextBois.text = "Bois : " + GameManager.instance.bois.ToString();
        GameManager.instance.ressourceTextPierre.text = "Pierre : " + GameManager.instance.pierre.ToString();
        GameManager.instance.ressourceTextOutils.text = "Outils : " + GameManager.instance.outils.ToString();
        posInit = transform.position;
        mouvement = true;
        onWork = false;
    }
    
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("NPC"), LayerMask.NameToLayer("Source"), true);
        posInit = transform.position;
        targetPos = RandomCoords();
        Forge = GameObject.FindGameObjectWithTag("Forge");
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("NPC"), LayerMask.NameToLayer("Forge"), true);
        //Debug.Log(targetPos); 
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Forge"))
        {
            if (onWork)
            {
                mouvement = false;
                StartCoroutine(WorkTime());
            }
            else
            {
                targetPos = RandomCoords();
            }
        }
        else if (other.gameObject.CompareTag("Maison"))
        {
            StartCoroutine(outilsInMaison());
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
