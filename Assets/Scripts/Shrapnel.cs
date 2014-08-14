using UnityEngine;

public class Shrapnel : MonoBehaviour
{
    private float _rotation;
    private float _speed;

    public float MinSpeed = 5;
    public float MaxSpeed = 10;

    void Start()
    {
        _rotation = Random.Range(0, 360);
        _speed = Random.Range(5, 10);
    }

    void Update()
    {
        // move piece of shrapnel by speed in direction
        // remove after certain time/ticks/whatever I settle on
    }
}