using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    #region Singleton
    private static Paddle _instance;
    public static Paddle Instance => _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion
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
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            Rigidbody2D ballRB = coll.gameObject.GetComponent<Rigidbody2D>();
            Vector3 hitPoint = coll.contacts[0].point;
            Vector3 paddleCenter = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);

            ballRB.velocity = Vector2.zero;

            float difference = paddleCenter.x - hitPoint.x;

            if (hitPoint.x < paddleCenter.x)
            {
                ballRB.AddForce(new Vector2(-(MathF.Abs(difference * 200)), BallsManager.Instance.initialBallSpeed));
            }
            else
            {
                ballRB.AddForce(new Vector2((MathF.Abs(difference * 200)), BallsManager.Instance.initialBallSpeed));
            }
        }
    }
}
