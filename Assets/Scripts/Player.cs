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
            if (!IsDead)
            {
                transform.Translate(
                    Input.GetAxisRaw("Horizontal") * Time.deltaTime * MoveSpeed,
                    Input.GetAxisRaw("Vertical") * Time.deltaTime * MoveSpeed,
                    0);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Bomb();
                }
            }
        }

        void Bomb()
        {
            IsDead = true;

            for (int i = 0; i < ShrapnelCount; i++)
            {
                var s = (GameObject)Instantiate(Resources.Load("Objects/Shrapnel"));
                s.transform.position = transform.position;
            }
        }
    }
}