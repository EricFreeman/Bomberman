using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class DefaultParticle : IParticle
    {
        #region IParticle Properties

        public int SortOrder { get; set; }
        public int Weight { get; set; }

        public float MinSpeed { get; set; }
        public float MaxSpeed { get; set; }

        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }

        #endregion

        public DefaultParticle()
        {
            SortOrder = 4;
            Weight = 1;

            MinSpeed = .1f;
            MaxSpeed = .3f;

            MinDistance = 0;
            MaxDistance = .4f;
        }

        public virtual void AssignEffects(GameObject obj) { }
    }
}
