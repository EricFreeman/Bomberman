using System.Linq;
using Assets.Scripts.Events;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour, IListener<ObjectBrokenMessage>
    {
        public bool IsDead = false;
        public float MoveSpeed = 1.5f;
        public int ShrapnelCount = 0;
        public float KillRadius = .75f;

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

            // Spawn Shrapnel
            Enumerable.Range(0, ShrapnelCount).Each(x =>
            {
                var s = (GameObject)Instantiate(Resources.Load("Objects/Shrapnel"));
                s.transform.position = transform.position;
            });

            // Destroy anything within kill radius
            FindObjectsOfType<BreakableObject>().Each(x =>
            {
                var distance = Vector3.Distance(x.transform.position, transform.position);
                if(distance <= KillRadius) x.Break(transform.position, distance);
            });
        }

        public void Handle(ObjectBrokenMessage message)
        {
            Debug.Log("Points Gained: " + message.Points);
        }
    }
}