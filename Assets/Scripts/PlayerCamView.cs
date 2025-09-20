using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamView : MonoBehaviour
{
    public float mouseSensitivity;

    private float mouseX;
    private float mouseY;
    [SerializeField] private Transform playerTransform;
    private Transform playerCam;

    public float maxCamTop;
    public float maxCamBottom;
    private float angle;

    void Awake()
    {
        playerCam = gameObject.transform;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        playerTransform.Rotate(Vector3.up, mouseX);

        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        angle -= mouseY;
        angle = Mathf.Clamp(angle, -maxCamBottom, maxCamTop);
        playerCam.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}
