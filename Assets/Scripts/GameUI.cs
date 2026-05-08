using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Slider healthBar;

    private int _score = 0;

    public void UpdateScore(int amount)
    {
        _score += amount;
        scoreText.text = "Очки: " + _score;
    }

    public void UpdateHealth(float value)
    {
        healthBar.value = value;
    }
}