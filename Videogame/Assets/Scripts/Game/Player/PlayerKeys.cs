using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeys : MonoBehaviour
{
    //private GameObject purpleKeyImage;
    //public Sprite purpleImage;
    public bool hasPurpleKey;
    public bool hasGreenKey;
    // Start is called before the first frame update
    void Start()
    {
        //purpleKeyImage = GameObject.Find("DreamCatcherImage");
        //Debug.Log(GameObject.Find("DreamCatcherImage"));
        hasPurpleKey = false;
        hasGreenKey = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DreamCatcherPurple"))
        {
            hasPurpleKey = true;
            //canvasGroup.alpha = 1;
            Destroy(collision.gameObject);
            //purpleKeyImage.GetComponent<Image>().sprite = purpleImage;
        }

        if (collision.CompareTag("DreamCatcherGreen"))
        {
            hasGreenKey = true;
            //canvasGroup.alpha = 1;
            Destroy(collision.gameObject);
            //purpleKeyImage.GetComponent<Image>().sprite = purpleImage;
        }
    }

    public bool GetPurpleKey()
    {
        return hasPurpleKey;
    }
    public bool GetGreenKey()
    {
        return hasGreenKey;
    }
}
