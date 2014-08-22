using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Events;
using Assets.Scripts.Particles;
using UnityEngine;

namespace Assets.Scripts
{
    public class BreakableObject : MonoBehaviour
    {
        #region Properties

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

        #endregion

        void Start()
        {
            Pc = new ParticleConfiguratior(Particles);
        }

        public void Break(Vector3 position, float distance)
        {
            IsBroken = true;

            var direction = position - transform.position;
            rigidbody2D.AddForceAtPosition(direction.normalized * Force * -1, position);

            SpawnParticles();
            ChangeSkin();

            EventAggregator.SendMessage(new ObjectBrokenMessage {Points = 5});
        }

        private void ChangeSkin()
        {
            if (BrokenSkin.Count == 0) return;
            GetComponent<SpriteRenderer>().sprite = SpecificSkin.HasValue ?
                BrokenSkin[SpecificSkin.Value] :
                BrokenSkin[Random.Range(0, BrokenSkin.Count)];
        }

        #region Particles

        private void SpawnParticles()
        {
            if (Particles.Count > 0)
            {
                Enumerable.Range(0, ParticleCount).Each(x =>
                {
                    var obj = (GameObject) Instantiate(Resources.Load("Particles/Particle"));
                    obj.transform.position = transform.position;

                    ConfigureParticle(obj);
                });
            }
        }

        private void ConfigureParticle(GameObject obj)
        {
            var p = obj.GetComponent<Particle>();
            var randomParticle = Pc.GetRandomParticle();
            var particleProperties = Pc.GetProperties(randomParticle);

            p.Speed = particleProperties.RandomSpeed();
            p.Distance = particleProperties.RandomDistance();
            p.GetComponent<SpriteRenderer>().sprite = randomParticle;
            p.GetComponent<SpriteRenderer>().sortingOrder = particleProperties.SortOrder;

            particleProperties.AssignEffects(obj);
        }

        #endregion
    }
}