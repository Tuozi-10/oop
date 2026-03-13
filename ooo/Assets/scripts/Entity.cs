using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Entity : MonoBehaviour
{
    public Vector2 target = new Vector2();
    public float speed = 0.005f;

    public enum Ressources
    {
        Wood,
        Stone,
        Sword
    }

    public void WalkTo(Vector2 pos)
    {
        Vector2 actualPos = transform.position;
        Vector2 vectorToApply = new Vector2();
        vectorToApply.x = (pos.x - actualPos.x);
        vectorToApply.y = (pos.y - actualPos.y);
        vectorToApply.Normalize();
        transform.Translate(vectorToApply * speed);
        
    }

    public bool Distanced(Vector2 pos)
    {
        return Vector2.Distance(pos, transform.position) > 1;
    }
}