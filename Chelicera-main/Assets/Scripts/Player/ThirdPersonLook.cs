using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonLook : MonoBehaviour
{

    [SerializeField] private float _mouseSensitivity = 100f;
    [SerializeField] private Transform _playerTransform;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        _playerTransform.Rotate(Vector3.up * mouseX);
    }
}
