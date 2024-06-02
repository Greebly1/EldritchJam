using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    private float screenWidth;
    private float screenHeight;

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
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Move the camera right
            if (Mathf.Abs(worldPoint.x - (Camera.main.transform.position.x + screenWidth)) <= 2)
            {
                Camera.main.transform.Translate(new Vector2(10 * Time.deltaTime, 0));
            }

            // Move the camera left
            if (Mathf.Abs(worldPoint.x - (Camera.main.transform.position.x - screenWidth)) <= 2)
            {
                Camera.main.transform.Translate(new Vector2(-10 * Time.deltaTime, 0));
            }

            // Move the camera up
            if (Mathf.Abs(worldPoint.y - (Camera.main.transform.position.y + screenHeight)) <= 2)
            {
                Camera.main.transform.Translate(new Vector2(0, 10 * Time.deltaTime));
            }

            // Move the camera right
            if (Mathf.Abs(worldPoint.y - (Camera.main.transform.position.y - screenHeight)) <= 2)
            {
                Camera.main.transform.Translate(new Vector2(0, -10 * Time.deltaTime));
            }
        }
    }
}
