using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        public bool IsDead = false;
        public float MoveSpeed = 1.5f;
        public int ShrapnelCount = 10;

        void Update()
        {
            if (IsDead) return;

            transform.Translate(
                Input.GetAxisRaw("Horizontal") * Time.deltaTime * MoveSpeed,
                Input.GetAxisRaw("Vertical") * Time.deltaTime * MoveSpeed,
                0);

            if (Input.GetKeyDown(KeyCode.Space)) Bomb();
        }

        void Bomb()
        {
            IsDead = true;

            Enumerable.Range(0, ShrapnelCount).Each(x =>
            {
                var s = (GameObject)Instantiate(Resources.Load("Objects/Shrapnel"));
                s.transform.position = transform.position;
            });
        }
    }
}