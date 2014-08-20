using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WaypointMovement : MonoBehaviour
    {
        public float MoveSpeed;
        public List<Vector3> Waypoints;

        private Vector3 _currentWaypoint;
        private int _index = 0;

        void Start()
        {
            _currentWaypoint = Waypoints.Count > 0 ? Waypoints[0] : Vector3.zero;
        }

        void Update()
        {
            if (Waypoints == null || Waypoints.Count == 0) return;

            transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint, MoveSpeed*Time.deltaTime);
            if (transform.position == _currentWaypoint)
            {
                if (_index++ == Waypoints.Count - 1) _index = 0;
                _currentWaypoint = Waypoints[_index];
            }
        }
    }
}