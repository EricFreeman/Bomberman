using UnityEngine;

namespace Assets.Scripts
{
    public class Bounds : MonoBehaviour
    {
        public Vector3 MinBound;
        public Vector3 MaxBound;

        // Force position inside of bounds
        public bool KeepInside = true;

        // Delete object outside of bounds
        public bool RemoveOutside;

        private Rect _collisionBox;

        void Start()
        {
            _collisionBox = new Rect
            {
                xMin = MinBound.x, 
                yMin = MinBound.y, 
                xMax = MaxBound.x, 
                yMax = MaxBound.y
            };
        }

        void Update()
        {
            if (_collisionBox.Contains(transform.position)) return;

            if (KeepInside)
                MoveInside();
            else if(RemoveOutside)
                Destroy(gameObject);
        }

        private void MoveInside()
        {
            if (transform.position.x < MinBound.x) transform.position = new Vector3(MinBound.x, transform.position.y);
            if (transform.position.x > MaxBound.x) transform.position = new Vector3(MaxBound.x, transform.position.y);

            if (transform.position.y < MinBound.y) transform.position = new Vector3(transform.position.x, MinBound.y);
            if (transform.position.y > MaxBound.y) transform.position = new Vector3(transform.position.x, MaxBound.y);
        }
    }
}