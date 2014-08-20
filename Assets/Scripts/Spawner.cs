using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Spawner : MonoBehaviour
    {
        public List<Transform> ToSpawn;
        public List<Vector3> Waypoints;
        public float XVariation;
        public float YVariation;

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

            var offset = GetSpawnOffset();
            var newObj = (GameObject)Instantiate(obj.gameObject, 
                transform.position + offset, 
                Quaternion.Euler(0, 0, SpawnRotation));

            newObj.AddComponent<WaypointMovement>().Waypoints = CreateNewWaypointList(offset);
            newObj.GetComponent<WaypointMovement>().MoveSpeed = 1;
        }

        private Vector3 GetSpawnOffset()
        {
            return new Vector3(Random.Range(-XVariation, XVariation), Random.Range(-YVariation, YVariation));
        }

        private List<Vector3> CreateNewWaypointList(Vector3 offset)
        {
            return Waypoints.Select(point => point + offset).ToList();
        }
    }
}