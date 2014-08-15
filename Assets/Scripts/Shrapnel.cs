using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Shrapnel : MonoBehaviour
{
    private float _rotation;
    private float _speed;

    public float MinSpeed = 5;
    public float MaxSpeed = 10;

    private Vector3 _spawnPosition;
    public float MaxDistance = 5;

    void Start()
    {
        _rotation = Random.Range(0, 360);
        _speed = Random.Range(MinSpeed, MaxSpeed);
        _spawnPosition = transform.position;
    }

    void Update()
    {
        var frameSpeed = _speed * Time.deltaTime;
        transform.Translate((float)Math.Cos(_rotation) * frameSpeed, (float)Math.Sin(_rotation) * frameSpeed, 0);

        if(Vector3.Distance(transform.position, _spawnPosition) > MaxDistance)
            Destroy(transform.gameObject);
    }
}