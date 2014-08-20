using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class WaypointMovement : MonoBehaviour
    {
        public float MoveSpeed;
        public List<Vector3> Waypoints;

        private Vector3 _currentWaypoint;
        private int _index;

        void Start()
        {
            _currentWaypoint = Waypoints.Count > 0 ? Waypoints[0] : Vector3.zero;
        }

        void Update()
        {
            if (Waypoints == null || Waypoints.Count == 0) return;
            if (IsBroken()) return;

            MoveToWaypoint();
            TurnTowardsWaypoint();
        }

        private void MoveToWaypoint()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentWaypoint, MoveSpeed*Time.deltaTime);
            if (transform.position == _currentWaypoint)
            {
                if (_index++ == Waypoints.Count - 1) _index = 0;
                _currentWaypoint = Waypoints[_index];
            }
        }

        private void TurnTowardsWaypoint()
        {
            var lookDir = _currentWaypoint - transform.position;
            transform.rotation = Quaternion.Euler(
                new Vector3(0, 0, Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg - 90));
        }

        private bool IsBroken()
        {
            var bo = GetComponent<BreakableObject>();
            return bo != null && bo.IsBroken;
        }
    }
}