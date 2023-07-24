using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject gameCamera;
    float delta;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        delta += Time.deltaTime;
        gameCamera.transform.Rotate(Mathf.Sin(delta * 3) / 40, Mathf.Sin(delta) / 10, Mathf.Sin(delta * 4) / 40);
    }
    
    public void StartButtonClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
