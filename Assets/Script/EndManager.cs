using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    [SerializeField] Text scoreText;
    [SerializeField] GameObject canvas1;
    [SerializeField] GameObject canvas2;
    [SerializeField] GameObject descriptionText;
    [SerializeField] Text StarText;
    int editCount = 0;
    [SerializeField] string[] descriptions;
    bool isChangeDescription = false;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EditScoreText", 2, 1.5f);
        Debug.Log(GameManager.scores);
    }

    // Update is called once per frame
    void Update()
    {
        if (isChangeDescription)
        {
            delta += Time.deltaTime / 5;
            descriptionText.GetComponent<Text>().text = descriptions[(int)delta % descriptions.Length];
        }
    }

    void EditScoreText()
    {
        editCount++;
        if (editCount < 8)
        {
            Debug.Log("Begined");
            switch (editCount)
            {
                case 1:
                    scoreText.text = "スーパーマーケット: " + GameManager.scores[0].ToString() + "点";
                    break;
                case 2:
                    AddResult(GameManager.scores[0]);
                    break;
                case 3:
                    scoreText.text += "\n" + "ホームセンター: " + GameManager.scores[1].ToString() + "点";
                    break;
                case 4:
                    StarText.text += "\n";
                    AddResult(GameManager.scores[1]);
                    break;
                case 5:
                    scoreText.text += "\n" + "100均: " + GameManager.scores[2].ToString() + "点";
                    break;
                case 6:
                    StarText.text += "\n";
                    AddResult(GameManager.scores[2]);
                    break;
                case 7:
                    scoreText.text += "\n\n" + "平均: " + (int)GameManager.scores.Average() + "点";
                    break;
            }
        }
        else if(editCount == 8)
        {
            ToDescription();
        }
    }

    void AddResult(int score)
    {
        if(score < 100) StarText.text += "★☆☆☆☆";
        else if (score >= 100 && score < 250) StarText.text += "★★☆☆☆";
        else if (score >= 250 && score < 400) StarText.text += "★★★☆☆";
        else if (score >= 400 && score < 550) StarText.text += "★★★★☆";
        else if (score >= 550) StarText.text += "★★★★★";
    }

    void ToDescription()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
        isChangeDescription = true;
    }
}
