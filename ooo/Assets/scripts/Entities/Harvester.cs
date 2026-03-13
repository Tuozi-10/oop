using UnityEngine;

namespace Entities
{
    
    [SelectionBase]
    public class Harvester : Entity
    {
        
        [HideInInspector] public Vector2 target;

        public EntityType entityType;

        private CurrentTarget _currentTarget = CurrentTarget.Harvest;

        public override void SetTarget()
        {
            target = _currentTarget switch
            {
                CurrentTarget.Harvest => GameManager.GetHarvestable(entityType).transform.position,
                CurrentTarget.Base => GameManager.startBase.transform.position,
                _ => target
            };
        }

        private void Start()
        {
            SetTarget();
            Debug.Log(target);
        }
    
        public override void OnFixedUpdate()
        {
            if (!MoveTo(target)) 
                return;
            
            if (_currentTarget == 0)
            {
                _currentTarget = (CurrentTarget)1;
            }
            else
            {
                _currentTarget = 0;
            }
            SetTarget();
        }
    }
}
