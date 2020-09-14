using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float SwingingSpeed = 2f;
    public float CooldownSpeed = 2f;

    public float AttackDuration = 0.35f;
    public float CooldownDuration = 0.5f;

    private Quaternion _targetRotation;
    private float _cooldownTimer;
    private bool _isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        _targetRotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, _targetRotation, Time.deltaTime * (_isAttacking ? SwingingSpeed : CooldownSpeed));
        _cooldownTimer -= Time.deltaTime;
    }

    public void Attack()
    {
        if (_cooldownTimer <= 0f)
        {
            _targetRotation = Quaternion.Euler(90, 0, 0);

            _cooldownTimer = CooldownDuration;
        }

        StartCoroutine(CooldownWait());
    }

    private IEnumerator CooldownWait()
    {
        _isAttacking = true;

        yield return new WaitForSeconds(AttackDuration);

        _isAttacking = false;
        _targetRotation = Quaternion.Euler(0, 0, 0);
    }
}
