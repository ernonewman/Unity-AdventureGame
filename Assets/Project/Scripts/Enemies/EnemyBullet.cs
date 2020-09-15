using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float Speed = 10f;
    public float LifeTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * Speed;
    }

    // Update is called once per frame
    void Update()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
