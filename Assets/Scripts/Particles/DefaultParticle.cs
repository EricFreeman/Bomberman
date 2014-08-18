namespace Assets.Scripts.Particles
{
    public class DefaultParticle : IParticle
    {
        public int SortOrder { get; set; }
        public int Weight { get; set; }

        public DefaultParticle()
        {
            SortOrder = 4;
            Weight = 1;
        }
    }
}
