using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class Shrapnel : MonoBehaviour
    {
        private float _rotation;
        private float _speed;

        public float MinSpeed = 5;
        public float MaxSpeed = 10;

        private Vector3 _spawnPosition;
        public float MaxDistance = 5;

        private float _distance { get { return Vector3.Distance(_spawnPosition, transform.position); } }

        private bool _destroyTrigger;

        void Start()
        {
            _rotation = Random.Range(0, 360);
            _speed = Random.Range(MinSpeed, MaxSpeed);
            _spawnPosition = transform.position;
        }

        void Update()
        {
            var frameSpeed = _speed * Time.deltaTime;
            transform.Translate((float)Math.Cos(_rotation) * frameSpeed, (float)Math.Sin(_rotation) * frameSpeed, 0);

            if (_distance > MaxDistance || _destroyTrigger)
                Destroy(transform.gameObject);
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            var obj = col.transform.GetComponent<BreakableObject>();
            if (obj != null && !obj.IsBroken)
            {
                obj.Break(_spawnPosition, _distance);
                _destroyTrigger = true;
            }
        }
    }
}