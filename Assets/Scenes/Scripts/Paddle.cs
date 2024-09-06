using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Camera mainCamera;
    private float paddleWidth = 6.5f; // Ширина платформы
    private float paddleHeight = 0.45f; // Высота платформы
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
        // Получаем позицию мыши в мировых координатах
        Vector3 mousePositionWorld = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0));

        // Вычисляем границы экрана в мировых координатах
        float leftBorder = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + paddleWidth / 2;
        float rightBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - paddleWidth / 2;

        // Ограничиваем позицию платформы в пределах границ экрана
        float clampedX = Mathf.Clamp(mousePositionWorld.x, leftBorder, rightBorder);

        // Обновляем позицию платформы
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }
}
