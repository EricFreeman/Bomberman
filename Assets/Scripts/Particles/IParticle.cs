namespace Assets.Scripts.Particles
{
    public interface IParticle
    {
        int SortOrder { get; set; }
        int Weight { get; set; }
    }
}
