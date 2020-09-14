using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Duration = 5f;
    public float Radius = 3f;


    private float _explosionTimer;

    // Start is called before the first frame update
    void Start()
    {
        _explosionTimer = Duration;
    }

    // Update is called once per frame
    void Update()
    {
        _explosionTimer -= Time.deltaTime;

        if (_explosionTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
