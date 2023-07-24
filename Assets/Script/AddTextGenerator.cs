using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddTextGenerator : MonoBehaviour
{
    public GameObject addTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(int amount)
    {
        GameObject obj = Instantiate(addTextPrefab, this.transform);
        obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-20, -140, 0);
        obj.GetComponent<Text>().text = (amount > 0 ? "+" : "") + amount.ToString();
        obj.GetComponent<Text>().color = amount > 0 ? new Color(0, 0, 255) : new Color(255, 0, 0);
    }
}
