﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class BreakableObject : MonoBehaviour
    {
        public bool IsBroken;
        public float Force = 100;

        public List<Sprite> Particles;
        public int ParticleCount = 5;

        public float MinDistance;
        public float MaxDistance;
        public float MinSpeed;
        public float MaxSpeed;

        public void Break(Vector3 position, float distance)
        {
            IsBroken = true;

            var direction = position - transform.position;
            rigidbody2D.AddForceAtPosition(direction.normalized * Force * -1, transform.position);

            if (Particles.Count > 0)
            {
                Enumerable.Range(0, ParticleCount).Each(x =>
                {
                    var obj = (GameObject) Instantiate(Resources.Load("Particles/Particle"));
                    obj.transform.position = transform.position;

                    var p = obj.GetComponent<Particle>();
                    p.Speed = Random.Range(MinSpeed, MaxSpeed);
                    p.Distance = Random.Range(MinSpeed, MaxSpeed);
                    p.GetComponent<SpriteRenderer>().sprite = Particles[Random.Range(0, Particles.Count)];
                });
            }
        }
    }
}