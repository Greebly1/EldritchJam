using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] GameObject topBorder;
    [SerializeField] GameObject bottomBorder;
    [SerializeField] GameManager gameManager;
    [HideInInspector] public int changeToState; // This variable is here to call the state transition mid scene animation

    // Perform the scene transition
    public void Init(int state)
    {
        changeToState = state;
        topBorder.GetComponent<RectTransform>().position = new Vector2(0, 9);
        bottomBorder.GetComponent<RectTransform>().position = new Vector2(0, -9);
    }

    // Update is called once per frame
    void Update()
    {
        if (topBorder.GetComponent<RectTransform>().position.y > -9)
        {
            topBorder.GetComponent<RectTransform>().Translate(Vector3.down * 30 * Time.deltaTime);
        }
        if (bottomBorder.GetComponent<RectTransform>().position.y < 9)
        {
            bottomBorder.GetComponent<RectTransform>().Translate(Vector3.up * 30 * Time.deltaTime);
        }

        if (Mathf.Abs(topBorder.GetComponent<RectTransform>().position.y - bottomBorder.GetComponent<RectTransform>().position.y) < 0.1f)
        {
            gameManager.ChangeState(changeToState);
        }
    }
}
