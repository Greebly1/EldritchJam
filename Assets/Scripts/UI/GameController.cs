using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public EldrichGlobalStats stats;

    [Header("Towers")]
    public GameObject tower1;
    public GameObject tower1Sprite;

    [Header("UI Elements")]
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject cancelButton;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text bloodText;
    [SerializeField] private Slider insightBar;
    [SerializeField] private Slider insanityBar;
    [SerializeField] private GameObject gameOverPopup;

    private bool draggingTower;
    private GameObject currentTower;
    private int currentTowerID;
    private bool hoveringOverButton;

    // Start is called before the first frame update
    void Start()
    {
        cancelButton.SetActive(false);
        gameOverPopup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Update stat text and bars
        healthText.text = "Health: " + stats.health.ToString();

        if (stats.health <= 0)
        {
            draggingTower = false;
            cancelButton.SetActive(false);
            panel.SetActive(false);
            if (currentTower != null) Destroy(currentTower);
            gameOverPopup.SetActive(true);
        }

        bloodText.text = "Blood: " + stats.blood.ToString();
        insightBar.value = stats.insight;
        insanityBar.value = stats.insanity;

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
