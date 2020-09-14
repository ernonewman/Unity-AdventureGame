using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float Duration = 5f;
    public float Radius = 3f;
    public float ExplosionDuration = 0.25f;
    public GameObject ExplosionModel;

    private float _explosionTimer;
    private bool _exploded;

    // Start is called before the first frame update
    void Start()
    {
        _explosionTimer = Duration;

        ExplosionModel.transform.localScale = Vector3.one * Radius;
        ExplosionModel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        _explosionTimer -= Time.deltaTime;

        if (_explosionTimer <= 0 && !_exploded)
        {
            _exploded = true;
            var _hitObjects = Physics.OverlapSphere(transform.position, Radius);

            foreach (var collider in _hitObjects)
            {
                Debug.Log($"{collider.name} was hit");
            }

            StartCoroutine(Explode());
        }
    }

    private IEnumerator Explode()
    {
        ExplosionModel.SetActive(true);

        yield return new WaitForSeconds(ExplosionDuration);

        Destroy(gameObject);
    }
}
