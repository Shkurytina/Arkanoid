using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Camera mainCamera;
    private float paddleWidth = 6.5f; // ������ ���������
    private float paddleHeight = 0.45f; // ������ ���������
    private float paddleInitialY;

    private void Start()
    {
        mainCamera = Camera.main; // Get the main camera
        paddleInitialY = this.transform.position.y;
    }

    private void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        // �������� ������� ���� � ������� �����������
        Vector3 mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0));

        // ��������� ������� ������ � ������� �����������
        float leftBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + paddleWidth / 2;
        float rightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - paddleWidth / 2;

        // ������������ ������� ��������� � �������� ������ ������
        float clampedX = Mathf.Clamp(mousePositionWorld.x, leftBorder, rightBorder);

        // ��������� ������� ���������
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
