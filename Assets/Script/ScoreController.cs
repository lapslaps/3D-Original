using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScoreController : MonoBehaviour
{
    ScoreManager scoreManager;
    public int score;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PointerClick()
    {
        Debug.Log("Clicked on object");
        AudioManager.instance.Play(clip);
        scoreManager.AddScore(score);
        Destroy(this.gameObject);
    }
}
