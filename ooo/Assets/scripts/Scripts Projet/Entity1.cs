using UnityEngine;

public abstract class Entity1 : MonoBehaviour
{
    protected float speed = 0.05f;
    protected Vector3 posMaison;

    void Awake()
    {
        GameObject maison = GameObject.FindGameObjectWithTag("Maison");
        posMaison = maison.transform.position;
    }
}
