using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public GameObject scoreText;
    public AddTextGenerator addTextGenerator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int score)
    {
        this.score += score;
        Debug.Log(this.score);
        scoreText.GetComponent<Text>().text = "score: " + this.score;
        addTextGenerator.ShowText(score);
    }
}
