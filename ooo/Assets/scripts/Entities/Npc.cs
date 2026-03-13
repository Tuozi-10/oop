using UnityEngine;

namespace Entities
{
    
    [SelectionBase]
    public class Npc : Entity
    {

        [SerializeField] private float movementRangeX = 5f;
        [SerializeField] private float movementRangeY = 8f;
        [HideInInspector] public Vector2 target;

        public EntityType entityType;

        public override void SetTarget()
        {
            target = new Vector2(Random.Range(-movementRangeX, movementRangeX),
                Random.Range(-movementRangeY, movementRangeY));
        }
    
        public override void OnFixedUpdate()
        {
            if (MoveTo(target))
            {
                SetTarget();
            }
        }
    }
}
