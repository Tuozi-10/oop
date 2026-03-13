
using UnityEngine;

namespace Entities
{
    public abstract class Entity : MonoBehaviour
    {

        public float speed = 0.01f;

        protected bool MoveTo(Vector2 target)
        {
            Vector2 direction = target - (Vector2)transform.position;
            direction.Normalize();
            direction *= speed;
            transform.Translate(direction);
            return Vector2.Distance(transform.position, target) <= 0.5f;
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

        public abstract void OnFixedUpdate();

        public abstract void SetTarget();

    }
}
