using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private float attackRate = 1f;

    private float _nextAttackTime = 0f;

    private void Update()
    {
        if (Time.time < _nextAttackTime) return;

        Collider[] hitPlayers = Physics.OverlapSphere(transform.position, attackRange);
        foreach (Collider player in hitPlayers)
        {
            if (player.CompareTag("Player") == false) continue;
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
            _nextAttackTime = Time.time + 1f / attackRate;
        }
    }
}
