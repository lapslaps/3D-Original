using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.Linq;

public class GameManager : MonoBehaviour
{
    bool doDecreaseTimer = true;
    Color[] backgroundColors = { new Color(1, 1, 0.6f), new Color(1, 0.6f, 1), new Color(0.6f, 1, 1) };
    public bool isGameStart = false;
    public double timer = 50;
    public GameObject timeObj;
    public GameObject canvas;
    public GameObject canvas1;
    public GameObject scoreText;
    public GameObject resultText;
    public GameObject background;
    public GameObject setsumeiUI;
    public GameObject objectsText;
    public GameObject mainasuText;
    public string[] objectStrings;
    public string[] mainasuStrings;
    public PhysicsRaycaster raycaster;
    public ScoreManager scoreManager;
    public string[] setsumeiStrings;
    public static int[] scores = new int[1];
    // Start is called before the first frame update
    void Start()
    {
        //PlayerController.gameLevel = 1;
        Debug.Log(PlayerController.gameLevel - 1);
        background.GetComponent<Renderer>().material.color = backgroundColors[PlayerController.gameLevel - 1];
        setsumeiUI.GetComponent<Text>().text = setsumeiStrings[PlayerController.gameLevel - 1];
        objectsText.GetComponent<Text>().text = objectStrings[PlayerController.gameLevel - 1];
        mainasuText.GetComponent<Text>().text = "とげボールは減点\n" + mainasuStrings[PlayerController.gameLevel - 1];
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void DecreaseTimer()
    {
        if (doDecreaseTimer)
        {
            if (timer > 0)
            {
                timer -= 1;
                timeObj.GetComponent<Text>().text = timer.ToString();
            }
            else
            {
                isGameStart = false;
                canvas.SetActive(true);
                raycaster.enabled = false;
                canvas1.SetActive(false);
                Invoke("ShowScore", 1.5f);
                doDecreaseTimer = false;
            }
        }
    }

    void ShowScore()
    {
        resultText.SetActive(true);
        scoreText.GetComponent<Text>().text = scoreManager.score.ToString() + "点";
    }

    public void StartButtonClicked()
    {
        isGameStart = true;
        this.gameObject.SetActive(false);
        InvokeRepeating("DecreaseTimer", 1.0f, 1.0f);
    }

    public void BackButtonClicked()
    {
        if (PlayerController.gameLevel != 3)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            SceneManager.LoadScene("EndScene");
        }
        PlayerController.clearLevel++;
        Debug.Log(PlayerController.gameLevel - 1);
        Array.Resize(ref scores, PlayerController.gameLevel);
        scores[scores.Length - 1] = scoreManager.score;
        Debug.Log(scores);
    }
}
