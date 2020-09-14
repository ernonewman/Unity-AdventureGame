using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float SwingingSpeed = 2f;

    private Quaternion _targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        _targetRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, _targetRotation, Time.deltaTime * SwingingSpeed);
    }

    public void Attack()
    {
        _targetRotation = Quaternion.Euler(-90, 0, 0);
    }
}
