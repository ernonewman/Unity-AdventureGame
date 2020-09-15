using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public GameObject Model;
    public float TimeToRotate = 2f;
    public float RotationSpeed = 6f;

    private Quaternion _targetRotation;
    private int _targetAngle;
    private float _rotationTimer;

    // Start is called before the first frame update
    void Start()
    {
        _rotationTimer = TimeToRotate;
    }

    // Update is called once per frame
    void Update()
    {
        _rotationTimer -= Time.deltaTime;

        if (_rotationTimer <= 0f)
        {
            _rotationTimer = TimeToRotate;

            _targetAngle += 90;
        }

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _targetAngle, 0), Time.deltaTime * RotationSpeed);
    }
}
