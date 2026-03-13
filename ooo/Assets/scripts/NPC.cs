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
    
    void Update()
    {
        MovetoTargetPosition();
        if (targetTransform == transform.position)
        {
            
            move();
        }
        
        if(Recolteur.nbWoodHome >= 2 && Recolteur.nbRockHome >= 2)
        {
            move(Forge);

            if (Vector3.Distance(transform.position,Forge.transform.position) <= 1f)
            {
                targetTransform = home.transform.position;
                Recolteur.nbWoodHome = 0;
                Recolteur.nbRockHome = 0;
                nbWeaponHome++;
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
