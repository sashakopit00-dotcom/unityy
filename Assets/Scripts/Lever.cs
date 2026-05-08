using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject platform;

    private bool _isActivated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false) return;

        _isActivated = !_isActivated;
        platform.SetActive(_isActivated);
        transform.Rotate(0, 0, _isActivated ? 45f : -45f);
        Debug.Log("Рычаг переключен!");
    }
}