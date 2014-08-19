using UnityEngine;

namespace Assets.Scripts.Particles.Effects
{
    public class Grow : MonoBehaviour
    {
        public float GrowPercentage;
        public int GrowTicks;

        private int _ticksRemaining;

        void Start()
        {
            _ticksRemaining = GrowTicks;
        }

        void Update()
        {
            if (_ticksRemaining-- <= 0) return;

            var size = (1 - (float) _ticksRemaining/GrowTicks) * (GrowPercentage + 1);
            transform.localScale = new Vector3(size, size, size);
        }
    }
}