using UnityEngine;

namespace Assets.Scripts
{
    public class RemoveOffscreen : MonoBehaviour
    {
        void Update()
        {
            if (!renderer.isVisible)
                DestroyImmediate(gameObject);
        }
    }
}