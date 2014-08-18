﻿namespace Assets.Scripts.Particles
{
    public class DefaultParticle : IParticle
    {
        public int SortOrder { get; set; }
        public int Weight { get; set; }
        public float Mass { get; set; }

        public DefaultParticle()
        {
            SortOrder = 4;
            Weight = 1;
            Mass = 1;
        }
    }
}
