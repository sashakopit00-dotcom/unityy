using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;

    private float timeRemaining = 60f;
    private Color _tmpColor;
    private Coroutine _timerBlink;

    private void Start() 
    {
        _tmpColor = timerText.color;
    }

    void Update()
    {
        if (timeRemaining < 15 && _timerBlink == null)
        {
            _timerBlink = StartCoroutine(FlashTimer());
        }
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timeRemaining).ToString();
        }
        else
        {
            Debug.Log("Время вышло!");
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().name
            );
        }
    }

    private IEnumerator FlashTimer()
    {
        timerText.color = Color.red;
        yield return new WaitForSeconds(0.4f);
        timerText.color = _tmpColor;
        yield return new WaitForSeconds(0.4f);
        _timerBlink = StartCoroutine(FlashTimer());
    }
}