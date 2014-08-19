using UnityEngine;

namespace Assets.Scripts.Particles.Effects
{
    public class Fade : MonoBehaviour
    {
        public int FadeTicks;
        private int _ticksRemaining;

        void Start()
        {
            _ticksRemaining = FadeTicks;
        }

        void Update()
        {
            var temp = renderer.material.color;
            temp.a = (float)_ticksRemaining--/FadeTicks;
            renderer.material.color = temp;

            if(temp.a <= 0)
                Destroy(gameObject);
        }
    }
}