using UnityEngine;
using Random = UnityEngine.Random;

public class NPC : Entity
{
    [SerializeField] private int limitMap = 12;
    [SerializeField] private GameObject home;
    [SerializeField] private GameObject Forge;
    
    public static  int nbWeaponHome = 0;
    
    

    void Start()
    {
        move();
    }
    
    // trop de choses dans ton update, hésite pas à déplacer la logique dans des fonctions, ca aidera à mieux comprendre ce qu'elles font,
    // là on a aucune idée de ce que ca fait, si t'avais déplacé ca dans un "moveLogic" ou whatever, on aurait un hint
    void Update()
    {
        MovetoTargetPosition();
        if (targetTransform == transform.position)
        {
            
            move();
        }
        
        // attention aux chiffres magiques en dur
        if(Recolteur.nbWoodHome >= 2 && Recolteur.nbRockHome >= 2)
        {
            move(Forge);

            if (Vector3.Distance(transform.position,Forge.transform.position) <= 1f)
            {
                targetTransform = home.transform.position;
                Recolteur.nbWoodHome = 0;
                Recolteur.nbRockHome = 0;
                nbWeaponHome++;
                // bof bof la logique de modif de l'UI dans ton npc, il a des responsabiltiés non souhaitées
                test.text = "weapons : " + nbWeaponHome.ToString();

            }
            
            
        }
        
        

    }
     

    public void move()
    {
        targetTransform = new Vector3(Random.Range(-limitMap, limitMap), Random.Range(-limitMap, limitMap));
    }

    public void move(GameObject forgeposition)
    {
        targetTransform = forgeposition.transform.position;
    }
}
