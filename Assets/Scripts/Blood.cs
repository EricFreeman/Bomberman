using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Blood : MonoBehaviour
    {
        public float Rotation;
        public float Distance;
        public float Speed;

        private Vector3 _startPosition;

        public void Start()
        {
            Rotation = Random.Range(0, 360);
            Distance = Random.Range(0, .5f);
            Speed = Random.Range(1, 3);

            _startPosition = transform.position;
        }

        public void Update()
        {
            if (!(Vector3.Distance(transform.position, _startPosition) < Distance)) return;

            var frameSpeed = Speed * Time.deltaTime;
            transform.Translate((float)Math.Cos(Rotation) * frameSpeed, (float)Math.Sin(Rotation) * frameSpeed, 0);
        }
    }
}