using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject tower1;
    public GameObject tower1Sprite;

    public GameObject panel;
    public GameObject cancelButton;

    private bool draggingTower;
    private GameObject currentTower;
    private int currentTowerID;
    private bool hoveringOverButton;

    // Start is called before the first frame update
    void Start()
    {
        cancelButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (draggingTower)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            currentTower.transform.position = new Vector3(worldPoint.x, worldPoint.y, 0);
        }

        if (Input.GetMouseButtonDown(0) && draggingTower && !hoveringOverButton)
        {
            draggingTower = false;
            cancelButton.SetActive(false);
            panel.SetActive(true);

            switch (currentTowerID)
            {
                case 0:
                    Instantiate(tower1, currentTower.transform.position, Quaternion.identity);
                    break;
                case 1:

                    break;
                case 2:

                  break;
            }

            Destroy(currentTower);
        }
    }

    public void DragTower(int towerID)
    {
        draggingTower = true;
        currentTowerID = towerID;
        cancelButton.SetActive(true);
        panel.SetActive(false);
        
        switch (towerID)
        {
            case 0:
                currentTower = Instantiate(tower1Sprite, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                break;
            case 1:

                break;
            case 2:

                break;
        }
    }

    public void CancelTowerPlacement()
    {
        draggingTower = false;
        cancelButton.SetActive(false);
        panel.SetActive(true);
        Destroy(currentTower);
    }

    public void ToggleHoveringOverButton(bool hovering)
    {
        hoveringOverButton = hovering;
    }
}
