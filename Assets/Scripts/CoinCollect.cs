using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    [SerializeField] private GameUI gameUI;
    [SerializeField] private AudioManage audioManage;
    [SerializeField] private int scoreValue = 10;

    private void OnTriggerEnter(Collider other) 
    {
        if (!other.CompareTag("Player")) return;

        gameUI.UpdateScore(scoreValue);
        audioManage.PlaySound("coin");
        Destroy(gameObject);
    }
}
