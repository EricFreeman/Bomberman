namespace Assets.Scripts.Particles
{
    public class BloodParticle : IParticle
    {
        public int SortOrder { get; set; }
        public int Weight { get; set; }
        public float Mass { get; set; }

        public BloodParticle()
        {
            SortOrder = 3;
            Weight = 10;
            Mass = 1;
        }
    }
}