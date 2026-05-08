using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float chaseRange = 10f;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance >= chaseRange) return;

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0; // Отключаем движение по вертикали
        _rb.MovePosition(_rb.position + direction * speed * Time.fixedDeltaTime);

        // Поворот врага в сторону игрока
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        _rb.rotation = Quaternion.Slerp(_rb.rotation, lookRotation, 10f * Time.fixedDeltaTime);
    }
}
