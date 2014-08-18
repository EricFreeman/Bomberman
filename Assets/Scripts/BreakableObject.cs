using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
        public List<int> ParticleWeight; 
        public int ParticleCount = 5;

        public float MinDistance;
        public float MaxDistance;
        public float MinSpeed;
        public float MaxSpeed;

        public void Break(Vector3 position, float distance)
        {
            IsBroken = true;

            var direction = position - transform.position;
            rigidbody2D.AddForceAtPosition(direction.normalized * Force * -1, transform.position);

            SpawnParticles();
            ChangeSkin();
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

                    var particle = GetRandomParticle();
                    p.GetComponent<SpriteRenderer>().sprite = particle;
                    // TODO: Remove this super hack until I can make a class encapsulating the sprite images with their weight and sort order instead of this hacky crap
                    p.GetComponent<SpriteRenderer>().sortingOrder = particle.name == "Blood" ? 3 : 4;
                });
            }
        }

        private void ChangeSkin()
        {
            if (BrokenSkin.Count == 0) return;
            GetComponent<SpriteRenderer>().sprite = SpecificSkin.HasValue ?
                BrokenSkin[SpecificSkin.Value] : 
                BrokenSkin[Random.Range(0, BrokenSkin.Count)];
        }

        private Sprite GetRandomParticle()
        {
            if(ParticleWeight == null || ParticleWeight.Count == 0)
                return Particles[Random.Range(0, Particles.Count)];

            var totalWeights = ParticleWeight.Sum();
            var selectedWeight = Random.Range(0, totalWeights);

            for(var i = 0; i < ParticleWeight.Count; i++)
            {
                selectedWeight -= ParticleWeight[i];
                if (selectedWeight <= 0) return Particles[i];
            }

            return Particles[0];
        }
    }
}