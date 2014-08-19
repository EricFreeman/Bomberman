using Assets.Scripts.Particles.Effects;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class SparkParticle : IParticle
    {
        #region Interface Properties

        public int SortOrder { get; set; }
        public int Weight { get; set; }

        public float MinSpeed { get; set; }
        public float MaxSpeed { get; set; }

        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }

        #endregion

        public SparkParticle()
        {
            SortOrder = 5;
            Weight = 10;

            MinDistance = 3f;
            MaxDistance = 4f;

            MinSpeed = 1f;
            MaxSpeed = 1.5f;
        }

        public void AssignEffects(GameObject obj)
        {
            obj.AddComponent<Fade>().FadeTicks = 30;
        }
    }
}
