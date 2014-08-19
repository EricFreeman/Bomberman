using System.Collections.Generic;
using Assets.Scripts.Particles.Effects;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class BloodParticle : IParticle
    {
        #region IParticle Properties

        public int SortOrder { get; set; }
        public int Weight { get; set; }

        public float MinSpeed { get; set; }
        public float MaxSpeed { get; set; }

        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }

        public List<MonoBehaviour> Effects { get; set; }

        #endregion

        public BloodParticle()
        {
            SortOrder = 3;
            Weight = 10;

            MinSpeed = .3f;
            MaxSpeed = .5f;

            MinDistance = 0;
            MaxDistance = .6f;
        }

        public void AssignEffects(GameObject obj)
        {
            obj.AddComponent<Grow>().GrowTicks = 60;
            obj.GetComponent<Grow>().GrowPercentage = .3f;
        }
    }
}