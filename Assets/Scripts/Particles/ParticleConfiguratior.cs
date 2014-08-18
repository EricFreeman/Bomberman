using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace Assets.Scripts.Particles
{
    public class ParticleConfiguratior
    {
        public Dictionary<Sprite, IParticle> ParticleProperties;
        public List<Sprite> Particles;

        private readonly int _cachedTotalWeight;

        public ParticleConfiguratior(List<Sprite> particles)
        {
            Particles = particles;
            ParticleProperties = new Dictionary<Sprite, IParticle>();
            particles.Each(x => ParticleProperties.Add(x, LoadParticleProperties(x.name)));
            _cachedTotalWeight = particles.Sum(x => LoadParticleProperties(x.name).Weight);
        }

        private IParticle LoadParticleProperties(string particleName)
        {
            var c = (IParticle)Assembly
                .GetExecutingAssembly()
                .CreateInstance("Assets.Scripts.Particles." + particleName + "Particle");

            return c ?? new DefaultParticle();
        }

        public Sprite GetRandomParticle()
        {
            var totalWeights = _cachedTotalWeight;
            var selectedWeight = Random.Range(0, totalWeights);

            for (var i = 0; i < Particles.Count(); i++)
            {
                selectedWeight -= GetProperties(Particles[i]).Weight;
                if (selectedWeight <= 0) return Particles[i];
            }
            
            return Particles[0];
        }

        public IParticle GetProperties(Sprite sprite)
        {
            return ParticleProperties[sprite] ?? new DefaultParticle();
        }
    }
}
