using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float rotationSpeed = 10f;

    void Update()
    {
        if (cameraTransform == null) return;

        Vector3 lookDir = cameraTransform.forward;

        lookDir.y = 0;
        if (lookDir == Vector3.zero) return;

        Quaternion targetRotation = Quaternion.LookRotation(lookDir);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
