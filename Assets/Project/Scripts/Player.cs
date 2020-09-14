using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Visuals")]
    public GameObject model;
    public float RotationSpeed = 2;


    [Header("Movement")]
    public float MovingVelocity;
    public float JumpingVelocity;

    [Header("Equipment")]
    public Sword PlayersSword;
    public Bow PlayersBow;
    public GameObject BombPrefab;
    public int BombAmount = 5;
    public float ThrowingSpeed;
    public int ArrowAmount = 10;

    private bool _canJump = false;
    private Rigidbody _playerRigidBody;
    private Quaternion _targetModelRotation;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
        _targetModelRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Raycast to identify if the player can jump;
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.01f))
        {
            _canJump = true;
        }

        model.transform.rotation = Quaternion.Lerp(model.transform.rotation, _targetModelRotation, Time.deltaTime * RotationSpeed);

        ProcessInput();
    }

    private void ProcessInput()
    {
        _playerRigidBody.velocity = new Vector3(0, _playerRigidBody.velocity.y, 0);

        // Move in the XZ plane
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerRigidBody.velocity = new Vector3(MovingVelocity, _playerRigidBody.velocity.y, _playerRigidBody.velocity.z);

            _targetModelRotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerRigidBody.velocity = new Vector3(-MovingVelocity, _playerRigidBody.velocity.y, _playerRigidBody.velocity.z);

            _targetModelRotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, _playerRigidBody.velocity.y, MovingVelocity);

            _targetModelRotation = Quaternion.Euler(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, _playerRigidBody.velocity.y, -MovingVelocity);

            _targetModelRotation = Quaternion.Euler(0, 180, 0);
        }

        //Check for jumps
        if (_canJump && Input.GetKeyDown(KeyCode.Space))
        {
            _canJump = false;
            _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, JumpingVelocity, _playerRigidBody.velocity.z);
        }

        // Check equipment interaction.

        if (Input.GetKey(KeyCode.Z))
        {
            PlayersSword.Attack();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (ArrowAmount > 0)
            {
                PlayersBow.Attack();
                ArrowAmount--;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ThrowBomb();
        }
    }

    private void ThrowBomb()
    {
        if (BombAmount > 0)
        {
            var bombObject = Instantiate(BombPrefab);

            bombObject.transform.position = transform.position + model.transform.forward;

            var throwingDirection = (model.transform.forward + Vector3.up).normalized;

            bombObject.GetComponent<Rigidbody>().AddForce(throwingDirection * ThrowingSpeed);

            BombAmount--;
        }
    }
}
