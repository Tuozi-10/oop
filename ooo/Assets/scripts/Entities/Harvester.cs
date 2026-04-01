using UnityEngine;

namespace Entities
{
    
    [SelectionBase]
    public class Harvester : Entity, IResource
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
    
        // pas turbo fan d'utiliser une fonction "générique", meme si c'est la tienne, on comprend pas trop
        // qu'elle est supposée faire le défilement jusqu'à atteindre, puis faire une action
        // dans ton cas, j'aurais surement appellé un MoveTo, puis un CheckTargetReached, là on comprends pas pourquoi MoveTo
        // si il retourne false on return, alors que c'est parce qu'il a atteint sa target
        // ca à part, c'est tres bien
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
            GameManager.TotalWood++;
            Debug.Log("total wood "+GameManager.TotalWood);
        }
    }
}
