using TMPro;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
        private float speed = 2f;
        
        protected Vector3 targetTransform;

        public entityData typeEntity;
        
        // pas incroyable le nom test chef
        [SerializeField] protected TextMeshProUGUI test;
        
        public void MovetoTargetPosition()
        { 
                transform.position = Vector3.MoveTowards(transform.position, targetTransform, speed * Time.deltaTime);
        }
        
    
        
        
}
