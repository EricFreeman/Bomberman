namespace Assets.Scripts.Particles
{
    public class BloodParticle : IParticle
    {
        public int SortOrder { get; set; }
        public int Weight { get; set; }

        public float MinSpeed { get; set; }
        public float MaxSpeed { get; set; }

        public float MinDistance { get; set; }
        public float MaxDistance { get; set; }

        public BloodParticle()
        {
            SortOrder = 3;
            Weight = 10;

            MinSpeed = .3f;
            MaxSpeed = .5f;

            MinDistance = 0;
            MaxDistance = .6f;
        }
    }
}