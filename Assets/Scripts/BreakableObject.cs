using UnityEngine;

namespace Assets.Scripts
{
    public class BreakableObject : MonoBehaviour
    {
        public bool IsBroken;
        public float Force = 100;

        public void Break(Vector3 position, float distance)
        {
            IsBroken = true;

            var direction = position - transform.position;
            rigidbody2D.AddForceAtPosition(direction.normalized * Force * -1, transform.position);
        }
    }
}