using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class TestCamera : MonoBehaviour
{
    private float screenWidth;
    private float screenHeight;

    public float sensitivity;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        screenHeight = Camera.main.orthographicSize;
        screenWidth = screenHeight * Camera.main.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) && gameManager.currentState == GameManager.GameStates.Game) // Right mouse button
        {
            Cursor.lockState = CursorLockMode.Locked;
            float mousePositionDeltaX = -Input.mousePositionDelta.x * 0.001f * sensitivity;
            float mousePositionDeltaY = -Input.mousePositionDelta.y * 0.001f * sensitivity;
            Camera.main.transform.position += new Vector3(mousePositionDeltaX, mousePositionDeltaY, 0);
            Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, -gameManager.currentMap.GetComponent<SpriteRenderer>().bounds.size.x / 2 + screenWidth, gameManager.currentMap.GetComponent<SpriteRenderer>().bounds.size.x / 2 - screenWidth),
                Mathf.Clamp(Camera.main.transform.position.y, -gameManager.currentMap.GetComponent<SpriteRenderer>().bounds.size.y / 2 + screenHeight, gameManager.currentMap.GetComponent<SpriteRenderer>().bounds.size.y / 2 - screenHeight),
                -10);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
