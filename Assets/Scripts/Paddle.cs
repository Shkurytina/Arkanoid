using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private Camera mainCamera;
    private float paddleInitialY;

    private void Start()
    {
        mainCamera = Find.ObjectOfType<Camera>();
        paddleInitialY = this.transform.position.y;
    }

    private void Update()
    {
        PaddleMovement();
    }

    private void PaddleMovement()
    {
        float mousePositionWorldX - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 0)).x;
        this.transform.position - new Vector3(mousePositionWorldX, paddleInitialY, 0);
    }
}
