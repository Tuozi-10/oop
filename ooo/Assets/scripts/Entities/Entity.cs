
using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviour
    {

        public float speed = 0.1f;
        [HideInInspector] public Vector2 target;
        public EntityType entityType;
        
        private int _harvested;
        protected int Harvested
        {
            get => _harvested;
            set
            {
                if (value < 0)
                {
                    _harvested = 0;
                    return;
                }
                _harvested = value;
            }
        }
        protected CurrentTarget _currentTarget = CurrentTarget.Harvest;
        
        protected bool MoveTo()
        {
            Vector2 direction = target - (Vector2)transform.position;
            direction.Normalize();
            direction *= speed;
            transform.Translate(direction);
            return Vector2.Distance(transform.position,target) <= 0.5f;
        }

        protected void MoveTo(float x, float y)
        {
            Vector2 direction = new Vector2(x,y) - new Vector2(transform.position.x,transform.position.y);
            direction.Normalize();
            direction *= speed;
            transform.Translate(direction);
        }

        private void FixedUpdate()
        {
            OnFixedUpdate();
            
        }

        protected abstract void OnFixedUpdate();

        protected abstract void SetTarget();

    }

    public interface IResource
    {
        public void AddResource();
        public void DropResource();
    }
}
