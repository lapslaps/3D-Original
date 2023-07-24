using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject[] prefabs1;
    public GameObject[] prefabs2;
    public GameObject[] prefabs3;
    public GameObject togetoge;
    float delta = 0;
    public float interval = 1;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        interval -= PlayerController.gameLevel * 0.1f;
        Debug.Log(interval);
        Debug.Log(PlayerController.gameLevel);
    }

    void Update()
    {
        if (gameManager.isGameStart)
        {
            delta += Time.deltaTime;

            if (delta > interval)
            {
                delta = 0;
                switch (PlayerController.gameLevel)
                {
                    case 1:
                        GameObject obj1 = Instantiate(Random.Range(0, 2) == 0 ? prefabs1[Random.Range(0, prefabs1.Length)] : togetoge, new Vector3(-16.0f, 2f, Random.Range(-7, 7)), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                        break;
                    case 2:
                        float leftOrRight1 = Random.Range(0, 2);
                        GameObject obj2 = Instantiate(Random.Range(0, 2) == 0 ? prefabs2[Random.Range(0, prefabs2.Length)] : togetoge, new Vector3(leftOrRight1 == 0 ? -16.0f : 16, 2f, Random.Range(-7, 7)), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                        obj2.GetComponent<ObjectController>().speed *= (leftOrRight1 == 0 ? 1 : -1);
                        break;
                    case 3:
                        float leftOrRight2 = Random.Range(0, 2);
                        GameObject obj3 = Instantiate(Random.Range(0, 2) == 0 ? prefabs3[Random.Range(0, prefabs3.Length)] : togetoge, new Vector3(leftOrRight2 == 0 ? -16.0f : 16, 2f, Random.Range(-7, 7)), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
                        obj3.GetComponent<ObjectController>().speed *= (leftOrRight2 == 0 ? 1 : -1);
                        break;
                }
            }
        }
    }
}
