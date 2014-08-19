using System;
using System.Collections.Generic;
using Assets.Scripts.Particles;

using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public static class Extensions
    {
        public static void Each<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var e in enumerable)
            {
                action(e);
            }
        }

        public static float RandomSpeed(this IParticle p)
        {
            return Random.Range(p.MinSpeed, p.MaxSpeed);
        }

        public static float RandomDistance(this IParticle p)
        {
            return Random.Range(p.MinDistance, p.MaxDistance);
        }
    }
}
