using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject ArrowPrefab;

    public void Attack()
    {
        GameObject arrowObject = Instantiate(ArrowPrefab);
        arrowObject.transform.position = transform.position + transform.forward;

        arrowObject.transform.forward = transform.forward;
    }
}
