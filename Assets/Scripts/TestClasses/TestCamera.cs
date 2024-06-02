using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    private float screenWidth;
    private float screenHeight;
    public float sensitivity;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) // Right mouse button
        {
            float mousePositionDeltaX = -Input.mousePositionDelta.x * 0.001f * sensitivity;
            float mousePositionDeltaY = -Input.mousePositionDelta.y * 0.001f * sensitivity;
            Camera.main.transform.position += new Vector3(mousePositionDeltaX, mousePositionDeltaY, 0);
        }
    }
}
