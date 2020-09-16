using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Enemy
{
    public GameObject Model;
    public float TimeToRotate = 2f;
    public float RotationSpeed = 6f;

    public GameObject BulletPrefab;
    public float TimeToShoot = 1f;

    private int _targetAngle;
    private float _rotationTimer;

    private float _shootingTimer;

    // Start is called before the first frame update
    void Start()
    {
        _rotationTimer = TimeToRotate;
        _shootingTimer = TimeToShoot;
    }

    // Update is called once per frame
    void Update()
    {
        // Update the enemy's angle.
        _rotationTimer -= Time.deltaTime;

        if (_rotationTimer <= 0f)
        {
            _rotationTimer = TimeToRotate;

            _targetAngle += 90;
        }

        // Perform the enemy rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, _targetAngle, 0), Time.deltaTime * RotationSpeed);

        // Shoot bullets
        _shootingTimer -= Time.deltaTime;

        if (_shootingTimer <= 0f)
        {
            _shootingTimer = TimeToShoot;

            GameObject bulletObject = Instantiate(BulletPrefab);
            bulletObject.transform.position = transform.position + Model.transform.forward;
            bulletObject.transform.forward = Model.transform.forward;
        }
    }
}
