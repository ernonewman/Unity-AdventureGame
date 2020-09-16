using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour
{
    public GameObject Target;
    public Vector3 Offset;
    public float FocusSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            transform.position = Vector3.Lerp(transform.position, Target.transform.position + Offset, Time.deltaTime * FocusSpeed);
        }
    }

}
