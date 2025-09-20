using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController playerController;

    private Transform playerTransform;
    public float movementSpeed;
    private float moveX;
    private float moveZ;
    private Vector3 moveDir;

    void Awake()
    {
        playerController = GetComponent<CharacterController>();
        playerTransform = GetComponent<Transform>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        moveDir = transform.right * moveX + transform.forward * moveZ;

        playerController.Move(moveDir * movementSpeed * Time.deltaTime);
    }
}
