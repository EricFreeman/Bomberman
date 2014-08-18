using UnityEngine;

namespace Assets.Scripts
{
    public class Person : MonoBehaviour
    {
        public Sprite[] Skins;

        public void Start()
        {
            if (Skins.Length > 0)
            {
                var randomSkin = Random.Range(0, Skins.Length);

                transform.GetComponent<SpriteRenderer>().sprite = Skins[randomSkin];
                GetComponent<BreakableObject>().SpecificSkin = randomSkin;
            }
        }
    }
}