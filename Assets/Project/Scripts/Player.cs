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

            _targetModelRotation = Quaternion.Euler(0, 270, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerRigidBody.velocity = new Vector3(-MovingVelocity, _playerRigidBody.velocity.y, _playerRigidBody.velocity.z);

            _targetModelRotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, _playerRigidBody.velocity.y, MovingVelocity);

            _targetModelRotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, _playerRigidBody.velocity.y, -MovingVelocity);

            _targetModelRotation = Quaternion.Euler(0, 0, 0);
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
    }
}
