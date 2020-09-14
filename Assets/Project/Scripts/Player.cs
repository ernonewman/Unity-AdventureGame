using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x + 5f * Time.deltaTime, transform.position.y, transform.position.z);
        //transform.position += new Vector3(5f * Time.deltaTime, 0, 0);
        transform.position += Vector3.right * 5f * Time.deltaTime;
    }
}
