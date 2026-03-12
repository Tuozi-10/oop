using UnityEngine;

public class Npc : Entity
{

    private Vector3 target = new Vector2(1, 1);
    public override void OnUpdate()
    {
        MoveTo(target);
    }
}
