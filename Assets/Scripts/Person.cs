using UnityEngine;

namespace Assets.Scripts
{
    public class Person : MonoBehaviour
    {
        public Sprite[] Skins;

        public void Start()
        {
            if (Skins.Length > 0)
                transform.GetComponent<SpriteRenderer>().sprite = Skins[Random.Range(0, Skins.Length)];
        }
    }
}