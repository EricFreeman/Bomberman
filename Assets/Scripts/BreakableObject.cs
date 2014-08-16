using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class BreakableObject : MonoBehaviour
    {
        public bool IsBroken;
        public float Force = 100;

        public List<Transform> Particles;
        public int ParticleCount = 5;

        public void Break(Vector3 position, float distance)
        {
            IsBroken = true;

            var direction = position - transform.position;
            rigidbody2D.AddForceAtPosition(direction.normalized * Force * -1, transform.position);

            Enumerable.Range(0, ParticleCount).Each(x =>
            {
                var p = (GameObject)Instantiate(Particles[0].gameObject);
                p.transform.position = transform.position;
            });
        }
    }
}