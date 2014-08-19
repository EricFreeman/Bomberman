namespace Assets.Scripts.Particles
{
    public interface IParticle
    {
        int SortOrder { get; set; }
        int Weight { get; set; }

        float MinSpeed { get; set; }
        float MaxSpeed { get; set; }

        float MinDistance { get; set; }
        float MaxDistance { get; set; }
    }
}
