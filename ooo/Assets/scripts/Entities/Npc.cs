using System;
using UnityEditorInternal;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Entities
{
    
    [SelectionBase]
    public class Npc : Entity, IResource
    {

        [SerializeField] private float movementRangeX = 5f;
        [SerializeField] private float movementRangeY = 8f;
        public bool canForge;

        protected override void SetTarget()
        {
            if (!canForge)
            {
                target = new Vector2(Random.Range(-movementRangeX, movementRangeX),
                    Random.Range(-movementRangeY, movementRangeY));
                return;
            }
            target = _currentTarget switch
            {
                CurrentTarget.Harvest => GameManager.forge.transform.position,
                CurrentTarget.Base => GameManager.startBase.transform.position,
                _ => target
            };
            
        }

        private void Start()
        {
            _currentTarget = CurrentTarget.Base;
        }

        protected override void OnFixedUpdate()
        {
            if (!MoveTo()) 
                return;

            if (canForge && (GameManager.TotalWood < 5 || GameManager.TotalRock < 5))
            {
                if (_currentTarget == CurrentTarget.Base)
                {
                    canForge = false;
                }
            }
            
            if (!canForge)
            {
                SetTarget();
            }
            else
            {
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
        }

        private void OnEnable()
        {
            GameManager.TotalReached += CanForge;
        }

        private void OnDisable()
        {
            GameManager.TotalReached -= CanForge;
        }

        private void CanForge()
        {
            canForge = true;
        }


        public void AddResource()
        {
            Harvested++;
            GameManager.TotalWood -= 5;
            GameManager.TotalRock -= 5;
        }

        public void DropResource()
        {
            Harvested--;
            GameManager.TotalSword++;
            Debug.Log("total sword" + GameManager.TotalSword);
        }
        
        
    }
}
