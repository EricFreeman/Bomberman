using UnityEngine;

namespace Assets.Scripts
{
    public class Person : MonoBehaviour
    {
        public bool IsDead = false;
        public float Force = 10;

        public void Kill(Vector3 position, float distance)
        {
            IsDead = true;

            var direction = position - transform.position;
            rigidbody2D.AddForceAtPosition(direction.normalized * Force * -1, transform.position);
        }
    }
}