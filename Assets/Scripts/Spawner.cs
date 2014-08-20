using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public List<Transform> ToSpawn;
        public List<Vector3> Waypoints; 

        public int MinSpawnDelay;
        public int MaxSpawnDelay;

        public float SpawnRotation;

        private int _spawnDelay;

        void Update()
        {
            if (ToSpawn.Count == 0 || _spawnDelay-- > 0) return;

            SpawnObject();
            _spawnDelay = Random.Range(MinSpawnDelay, MaxSpawnDelay);
        }

        private void SpawnObject()
        {
            var obj = ToSpawn[Random.Range(0, ToSpawn.Count)];

            var newObj = (GameObject)Instantiate(obj.gameObject, transform.position, Quaternion.Euler(0, 0, SpawnRotation));
            newObj.AddComponent<WaypointMovement>().Waypoints = Waypoints;
            newObj.GetComponent<WaypointMovement>().MoveSpeed = 1;
        }
    }
}