using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private GameUI gameUI;

    private int _currentHealth;

    private void Start()
    {
        _currentHealth = maxHealth;
        gameUI.UpdateHealth(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        gameUI.UpdateHealth(_currentHealth);
        if (_currentHealth <= 0)
        {
            Debug.Log("Игрок погиб");
            Destroy(gameObject);
        }
    }
}
