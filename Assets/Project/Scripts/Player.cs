using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MovingVelocity;
    public float JumpingVelocity;

    private bool _canJump = false;
    private Rigidbody _playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody>();
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
        ProcessInput();
    }

    private void ProcessInput()
    {
        _playerRigidBody.velocity = new Vector3(0, _playerRigidBody.velocity.y, 0);

        // Move in the XZ plane
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerRigidBody.velocity = new Vector3(MovingVelocity, _playerRigidBody.velocity.y, _playerRigidBody.velocity.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerRigidBody.velocity = new Vector3(-MovingVelocity, _playerRigidBody.velocity.y, _playerRigidBody.velocity.z);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, _playerRigidBody.velocity.y, MovingVelocity);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, _playerRigidBody.velocity.y, -MovingVelocity);
        }

        //Check for jumps
        if (_canJump && Input.GetKeyDown(KeyCode.Space))
        {
            _canJump = false;
            _playerRigidBody.velocity = new Vector3(_playerRigidBody.velocity.x, JumpingVelocity, _playerRigidBody.velocity.z);
        }
    }
}
