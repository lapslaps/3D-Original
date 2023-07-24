using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IroiroController : MonoBehaviour
{
    public GameObject keyText;
    public Sprite[] mysteryPNG;
    public GameObject imageUI;
    public bool isSelected = false;
    public GameObject[] oneCoinShopBlock;
    public GameObject[] homeCenterShopBlock;
    public GameObject[] SuperMarketShopBlock;
    public GameObject annaiUI;
    public GameObject ryukkuText;
    public String[] annaiString;
    string collidedTag;
    public string[] shopTags = {"MarketSensor"};
    bool isCollided = false;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.clearLevel > 0)
        {
            foreach(GameObject obj in homeCenterShopBlock)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in SuperMarketShopBlock)
            {
                obj.SetActive(true);
            }
            if (PlayerController.clearLevel > 1)
            {
                foreach (GameObject obj in oneCoinShopBlock)
                {
                    obj.SetActive(false);
                }
                foreach (GameObject obj in homeCenterShopBlock)
                {
                    obj.SetActive(true);
                }
            }
        }
        annaiUI.GetComponent<Text>().text = annaiString[PlayerController.clearLevel];
        if(PlayerController.clearLevel > 0)
        {
            ryukkuText.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isCollided && !isSelected)
        {
            isSelected = true;
            int index = Array.IndexOf(shopTags, collidedTag) + 1;
            PlayerController.gameLevel = index;
            SceneManager.LoadScene("GameScene");
            Debug.Log(index + " " + collidedTag);
        }
        if (Input.GetKeyDown(KeyCode.Escape) && isSelected)
        {
            imageUI.GetComponent<Image>().color = new Color(255, 255, 255, 0);
            keyText.GetComponent<Text>().text = "";
            isSelected = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Untagged") return;
        Debug.Log(other.gameObject.name);
        collidedTag = other.gameObject.tag;
        if (shopTags.Contains(collidedTag) && !isSelected)
        {
            keyText.GetComponent<Text>().text = "[Ｅ]グッズを集めに行く";
            isCollided = true;
        }
        else if(collidedTag == "Bag" && !isSelected && PlayerController.clearLevel < 0)
        {
            keyText.GetComponent<Text>().text = "[Ｅ]物を入れる";
            isCollided = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Untagged") return;
        //collidedTag = other.gameObject.tag;
        if (shopTags.Contains(collidedTag) && !isSelected)
        {
            keyText.GetComponent<Text>().text = "";
            isCollided = false;
        }
    }

    public void submitText(string text)
    {

    }
}
