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
    public GameObject tower2;
    public GameObject tower2Sprite;
    public GameObject tower3;
    public GameObject tower3Sprite;

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
    private GameObject selectedTower;

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
                    stats.SpendBlood(tower1.GetComponent<Tower>().placeCost);
                    Instantiate(tower1, currentTower.transform.position, Quaternion.identity);
                    break;
                case 1:
                    stats.SpendBlood(tower2.GetComponent<Tower>().placeCost);
                    Instantiate(tower2, currentTower.transform.position, Quaternion.identity);
                    break;
                case 2:
                    stats.SpendBlood(tower3.GetComponent<Tower>().placeCost);
                    Instantiate(tower3, currentTower.transform.position, Quaternion.identity);
                    break;
            }

            Destroy(currentTower);
        }
    }

    public void DragTower(int towerID)
    {
        switch (towerID)
        {
            case 0:
                if (stats.blood >= tower1.GetComponent<Tower>().placeCost)
                {
                    draggingTower = true;
                    currentTowerID = towerID;
                    cancelButton.SetActive(true);
                    panel.SetActive(false);
                    currentTower = Instantiate(tower1Sprite, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                }
                break;
            case 1:
                if (stats.blood >= tower1.GetComponent<Tower>().placeCost)
                {
                    draggingTower = true;
                    currentTowerID = towerID;
                    cancelButton.SetActive(true);
                    panel.SetActive(false);
                    currentTower = Instantiate(tower2Sprite, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                }
                break;
            case 2:
                if (stats.blood >= tower1.GetComponent<Tower>().placeCost)
                {
                    draggingTower = true;
                    currentTowerID = towerID;
                    cancelButton.SetActive(true);
                    panel.SetActive(false);
                    currentTower = Instantiate(tower3Sprite, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
                }
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

    public void SetSelectedTower()
    {
        
    }
}
