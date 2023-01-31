using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    [SerializeField] private float sensX;
    [SerializeField] private float sensY;

    [SerializeField] private Transform orientation;

    private float rotationX;
    private float rotationY;

    public bool canMove;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        canMove = true;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {
            CameraManager.Instance.ToggleCamera(0);
        }

        if (!canMove)
        {
            return;
        }

        Vector2 mouseInput = InputManager.Instance.InputActions.Player.MouseLook.ReadValue<Vector2>();

        float mouseX = mouseInput.x * Time.deltaTime * sensX;
        float mouseY = mouseInput.y * Time.deltaTime * sensY;

        rotationY += mouseX;
        rotationX -= mouseY;

        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);
        orientation.rotation = Quaternion.Euler(0, rotationY, 0);
    }
}
