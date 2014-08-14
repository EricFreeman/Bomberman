using UnityEngine;

public class Player : MonoBehaviour
{
    public bool IsDead = false;
    public float MoveSpeed = 1.5f;

    void Update()
    {
        if (!IsDead)
        {
            transform.Translate(
                Input.GetAxisRaw("Horizontal") * Time.deltaTime * MoveSpeed,
                Input.GetAxisRaw("Vertical") * Time.deltaTime * MoveSpeed,
                0);
        }
    }
}