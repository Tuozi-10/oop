using UnityEngine;

// pour ta classe abstraite, je te conseille plutot de l'appeller Abs_Entity par exemple, pour qu'on comprenne que c'est la mamie de tes entités
public abstract class Entity1 : MonoBehaviour
{
    protected float speed = 0.05f;
    protected Vector3 posMaison;

    void Awake()
    {
        // hésite pas si tu peux faire un lien direct de le faire, c'est assez couteux les findGameObject ( bon apres dans un awake c'est OK mais ca reste couteux )
        GameObject maison = GameObject.FindGameObjectWithTag("Maison");
        posMaison = maison.transform.position;
    }
}
