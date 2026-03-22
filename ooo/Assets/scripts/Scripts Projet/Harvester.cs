using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Harvester : NPC
{
    private GameManager gameManager;
    private bool transport = false;
    private bool mouvement = true;
    private Collider2D colliderMaison;
    private int ressourcePorter;
    private List<Recoltable> ressources = new List<Recoltable>();
    IEnumerator Recolte(GameObject other)
    {
        Recoltable _recoltable = other.GetComponent<Recoltable>();
        
        // pareil variable en dur
        yield return new WaitForSeconds(3);
        if (_recoltable != null)
        {
            // si tu veux pas t'embeter à le faire en code tu pourrais faire ca directement dans les project settings,
            // et ca évite de pas comprendre si un jour tu les réactives pourquoi quand tu lances le jeu ca les redésactive
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Harvester"), LayerMask.NameToLayer("Source"), true);
            mouvement = true;
            transport = true;
            _recoltable.RessourceRecolte();
        }
    }

    IEnumerator Transport()
    {
        Debug.Log("je commence à charger les ressources");
        yield return new WaitForSeconds(3);
        posInit = transform.position;
        ressources = FindObjectsByType<Recoltable>(FindObjectsSortMode.None).ToList();
        GoToRessource(ressources);
        mouvement = true;
        transport = false;
        // HA je viens de comprendre pourquoi tu fais ca, ca risque pas de peter les collisions de tes autres entités ? 
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Harvester"), LayerMask.NameToLayer("Source"), false);
        GameManager.instance.IncrementRessource(ressourcePorter);
        Debug.Log("Fini de transporter ressources");
        Debug.Log("prochaine destination" + targetPos);
    }
    
    
    void Start()
    {
        estNPC = false;
        // gaffe au ToList, ca utilise du LinQ, encore un peu couteux sur notre version de C# utilisé par unity
        ressources = FindObjectsByType<Recoltable>(FindObjectsSortMode.None).ToList();
        GoToRessource(ressources);
        posInit = transform.position;
    }

    // le naming est pas bon du tout, j'pensais que ca déplacait l'entité, alors que c'est un gros getter de la ressource la plus proche
    // il te manque d'ailleurs la séparation arbre / pierre, là ca prend la plus proche
    // et c'est tout ( mais en relisant ce que je t'avais dit par MP, c'était pas précisé, donc my bad ca sera pas compté)
    private void GoToRessource(List<Recoltable> ressource)
    {
        if (ressource.Count == 0)
        {
            Debug.Log("La liste est complètement vide au départ !");
            return;
        }
    
        GameObject sourcePlusProche = null;
        // float.Min/maxvalue ?
        float distancePlusPetite = 10000000000000;
        float distance;
    
        for (int i = 0; i < ressource.Count; i++)
        {
            if (ressource[i] == null)
            {
                continue;
            }
            distance = Vector3.Distance(transform.position, ressource[i].transform.position);
            if (ressource[i].ressourceDispo == true && distance <= distancePlusPetite)
            {
                distancePlusPetite = distance;
                sourcePlusProche = ressource[i].gameObject;
            }
        }
        if (sourcePlusProche != null)
        {
            targetPos = sourcePlusProche.transform.position;
        }
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
                posInit = transform.position;
                targetPos = posMaison;
                transform.Translate( new Vector3(targetPos.x - posInit.x,targetPos.y - posInit.y).normalized * speed);
            }
            else
            {
                base.Move();
            }
        }
        
    }
}
