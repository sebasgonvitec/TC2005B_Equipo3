/*
 Script to store catched dreamcatchers (Keys)

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 15/05/2022
 
 */

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
    public bool hasPinkKey;

    public GameObject imagePrefab;
    public Transform inventory;
    
    void Start()
    {
        //purpleKeyImage = GameObject.Find("DreamCatcherImage");
        //Debug.Log(GameObject.Find("DreamCatcherImage"));
        hasPurpleKey = false;
        hasGreenKey = false;
        hasPinkKey = false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check which Dreamcatcher to catch based on the Tag

        if (collision.CompareTag("DreamCatcherPurple"))
        {
            var dc = Instantiate(imagePrefab, inventory);
            dc.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            hasPurpleKey = true;
            //canvasGroup.alpha = 1;
            Destroy(collision.gameObject);
            //purpleKeyImage.GetComponent<Image>().sprite = purpleImage;
        }

        if (collision.CompareTag("DreamCatcherGreen"))
        {
            var dc = Instantiate(imagePrefab, inventory);
            dc.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            hasGreenKey = true;
            //canvasGroup.alpha = 1;
            Destroy(collision.gameObject);
            //purpleKeyImage.GetComponent<Image>().sprite = purpleImage;
        }

        if (collision.CompareTag("DreamCatcherPink"))
        {
            var dc = Instantiate(imagePrefab, inventory);
            dc.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            hasPinkKey = true;
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
    public bool GetPinkKey()
    {
        return hasPinkKey;
    }
}
