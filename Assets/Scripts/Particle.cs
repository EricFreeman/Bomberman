using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Particle : MonoBehaviour
    {
        private float _rotation;

        [HideInInspector]
        public float Distance;

        [HideInInspector]
        public float Speed;

        private Vector3 _startPosition;

        public void Start()
        {
            _rotation = Random.Range(0, 360);

            _startPosition = transform.position;
        }

        public void Update()
        {
            if (!(Vector3.Distance(transform.position, _startPosition) < Distance)) return;

            var frameSpeed = Speed * Time.deltaTime;
            transform.Translate((float)Math.Cos(_rotation) * frameSpeed, (float)Math.Sin(_rotation) * frameSpeed, 0);
        }
    }
}