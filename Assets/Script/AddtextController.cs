using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddtextController : MonoBehaviour
{
    RectTransform rect;
    CanvasGroup group;
    public float moveSpeed;
    public float fadeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        group = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.anchoredPosition = new Vector3(0, rect.anchoredPosition.y + moveSpeed * Time.deltaTime, 0);
        group.alpha += fadeSpeed * Time.deltaTime;
        if(group.alpha <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
