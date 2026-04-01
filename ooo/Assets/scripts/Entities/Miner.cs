using UnityEngine;

namespace Entities
{
    
    [SelectionBase]
    public class Miner : Entity, IResource
    {
        

        protected override void SetTarget()
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
        }
    
        // tu as du code duppliqué ici, c'est dommage ton Harvester fait littéralement la meme chose à l'exception du petit total rock en bas
        // tu aurais pu n'avoir qu'une seule classe et un "harvestableType"
        protected override void OnFixedUpdate()
        {
            if (!MoveTo()) 
                return;
                
            if (_currentTarget == CurrentTarget.Base)
            {
                _currentTarget = CurrentTarget.Harvest;
                DropResource();
            }
            else
            {
                _currentTarget = CurrentTarget.Base;
                AddResource();
            }
            SetTarget();
        }


        public void AddResource()
        {
            Harvested++;
        }

        public void DropResource()
        {
            Harvested--;
            GameManager.TotalRock++;
            Debug.Log("total rock" + GameManager.TotalRock);
        }
    }
}
