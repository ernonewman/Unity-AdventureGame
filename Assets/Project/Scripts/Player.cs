﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float JumpingForce = 150;
    private bool _canJump = false;

    // Start is called before the first frame update
    void Start()
    {

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
        // Move in the XZ plane
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position = new Vector3(transform.position.x + 5f * Time.deltaTime, transform.position.y, transform.position.z);
            //transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
            transform.position += Vector3.right * 5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * 5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.forward * 5f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.back * 5f * Time.deltaTime;
        }

        //Check for jumps
        if (_canJump && Input.GetKeyDown(KeyCode.Space))
        {
            _canJump = false;
            GetComponent<Rigidbody>().AddForce(0, JumpingForce, 0);
        }
    }
}
