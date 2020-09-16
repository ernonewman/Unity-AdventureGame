using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrollingLogic : MonoBehaviour
{
    public Vector3[] Directions;
    public float TimeToChange = 1f;
    public float MovementSpeed;

    private int _directionPointer;
    private float _directionTimer;


    // Start is called before the first frame update
    void Start()
    {
        _directionPointer = 0;
        _directionTimer = TimeToChange;
    }

    // Update is called once per frame
    void Update()
    {
        // Changing the direction
        _directionTimer -= Time.deltaTime;

        if (_directionTimer <= 0)
        {
            _directionTimer = TimeToChange;
            _directionPointer++;

            if (_directionPointer >= Directions.Length)
            {
                _directionPointer = 0;
            }
        }

        // Make the object move
        GetComponent<Rigidbody>().velocity =
            new Vector3(
                Directions[_directionPointer].x * MovementSpeed,
                GetComponent<Rigidbody>().velocity.y,
                Directions[_directionPointer].z * MovementSpeed);
    }
}
