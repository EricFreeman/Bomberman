namespace Assets.Scripts.Particles
{
    public class DefaultParticle : IParticle
    {
        public int SortOrder { get; set; }
        public int Weight { get; set; }

        public float MinSpeed { get; set; }
        public float MaxSpeed { get; set; }

        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }

        public DefaultParticle()
        {
            SortOrder = 4;
            Weight = 1;

            MinSpeed = .1f;
            MaxSpeed = .3f;

            MinDistance = 0;
            MaxDistance = .2f;
        }
    }
}
