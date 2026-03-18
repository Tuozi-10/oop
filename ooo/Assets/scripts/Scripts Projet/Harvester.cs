using System;
using System.Collections;
using UnityEngine;

public class Harvester : NPC
{
    private GameManager gameManager;
    private Vector3 posMaison;
    private bool transport = false;
    private bool mouvement = true;
    private Collider2D colliderMaison;
    private int ressourcePorter;
    IEnumerator Recolte(GameObject other)
    {
        Recoltable _recoltable = other.GetComponent<Recoltable>();
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Harvester"), LayerMask.NameToLayer("Source"), true);
        mouvement = true;
        transport = true;
        _recoltable.RessourceRecolte();
    }

    IEnumerator Transport()
    {
        Debug.Log("je commence à charger les ressources");
        yield return new WaitForSeconds(3);
        targetPos = RandomCoords();
        mouvement = true;
        transport = false;
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Harvester"), LayerMask.NameToLayer("Source"), false);
        GameManager.instance.IncrementRessource(ressourcePorter);
        Debug.Log("Fini de transporter ressources");
    }
    void Start()
    {
        GameObject maison = GameObject.FindGameObjectWithTag("Maison");
        colliderMaison = maison.GetComponent<Collider2D>();
        posMaison = maison.transform.position;
        posInit = transform.position;
        targetPos = RandomCoords();
    }

    void FixedUpdate()
    {
        if (moveEnd == false)
        {
            Move();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("truc touché");
        if (other.gameObject.layer == LayerMask.NameToLayer("Source"))
        {
            if (other.gameObject.tag == "arbre")
            {
                ressourcePorter = 1;
            }
            else if (other.gameObject.tag == "pierre")
            {
                ressourcePorter = 2;
            }
            mouvement = false;
            StartCoroutine(Recolte(other.gameObject));
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Maison") && transport == true)
        {
            Debug.Log("maison touché");
            mouvement = false;
            StartCoroutine(Transport());
        }
    }

    public override void Move()
    {
        if (mouvement == true)
        {
            if (transport == true)
            {
                colliderMaison.enabled = true;
                posInit = transform.position;
                targetPos = posMaison;
                transform.Translate( new Vector3(targetPos.x - posInit.x,targetPos.y - posInit.y).normalized * speed);
            }
            else
            {
                base.Move();
                colliderMaison.enabled = false;
            }
        }
        
    }
}
