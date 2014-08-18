using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts
{
    public class BreakableObject : MonoBehaviour
    {
        [HideInInspector]
        public bool IsBroken;

        // Object Properties
        public float Force = 100;
        public List<Sprite> BrokenSkin;
        public int? SpecificSkin;

        // Particle Properties
        public List<Sprite> Particles;
        public int ParticleCount = 5;

        public ParticleConfiguratior Pc;

        public float MinDistance;
        public float MaxDistance;
        public float MinSpeed;
        public float MaxSpeed;

        public void Start()
        {
            Pc = new ParticleConfiguratior(Particles);
        }

        public void Break(Vector3 position, float distance)
        {
            IsBroken = true;

            var direction = position - transform.position;
            rigidbody2D.AddForceAtPosition(direction.normalized * Force * -1, transform.position);

            SpawnParticles();
            ChangeSkin();
        }

        private void ChangeSkin()
        {
            if (BrokenSkin.Count == 0) return;
            GetComponent<SpriteRenderer>().sprite = SpecificSkin.HasValue ?
                BrokenSkin[SpecificSkin.Value] :
                BrokenSkin[Random.Range(0, BrokenSkin.Count)];
        }

        private void SpawnParticles()
        {
            if (Particles.Count > 0)
            {
                Enumerable.Range(0, ParticleCount).Each(x =>
                {
                    var obj = (GameObject) Instantiate(Resources.Load("Particles/Particle"));
                    obj.transform.position = transform.position;

                    var p = obj.GetComponent<Particle>();
                    p.Speed = Random.Range(MinSpeed, MaxSpeed);
                    p.Distance = Random.Range(MinSpeed, MaxSpeed);

                    var particle = Pc.GetRandomParticle();
                    var particleProperties = Pc.GetProperties(particle);
                    p.GetComponent<SpriteRenderer>().sprite = particle;
                    p.GetComponent<SpriteRenderer>().sortingOrder = particleProperties.SortOrder;
                });
            }
        }
    }
}