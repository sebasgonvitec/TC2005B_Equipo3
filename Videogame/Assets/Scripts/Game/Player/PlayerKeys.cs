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

    [SerializeField] private AudioSource dc1;
    [SerializeField] private AudioSource dc2;
    [SerializeField] private AudioSource dc3;

    private GameObject[] greenDcs;
    private GameObject[] purpleDcs;
    private GameObject[] pinkDcs;
    private GameObject[] imagePrefabs;
    void Start()
    {
        //purpleKeyImage = GameObject.Find("DreamCatcherImage");
        //Debug.Log(GameObject.Find("DreamCatcherImage"));
        hasPurpleKey = false;
        hasGreenKey = false;
        hasPinkKey = false;
    }

    private void Update()
    {
        if (MakerMode.playMode == false)
        {
            hasPurpleKey = false;
            hasGreenKey = false;
            hasPinkKey = false;

            greenDcs = GameObject.FindGameObjectsWithTag("DreamCatcherGreen");
            purpleDcs = GameObject.FindGameObjectsWithTag("DreamCatcherPurple");
            pinkDcs = GameObject.FindGameObjectsWithTag("DreamCatcherPink");

            for (int i = 0; i < greenDcs.Length; i++)
            {
                greenDcs[i].GetComponent<SpriteRenderer>().sortingLayerName = "Portals";
                greenDcs[i].GetComponent<Collider2D>().enabled = true;
            }
            for (int i = 0; i < purpleDcs.Length; i++)
            {
                purpleDcs[i].GetComponent<SpriteRenderer>().sortingLayerName = "Portals";
                purpleDcs[i].GetComponent<Collider2D>().enabled = true;
            }
            for (int i = 0; i < pinkDcs.Length; i++)
            {
                pinkDcs[i].GetComponent<SpriteRenderer>().sortingLayerName = "Portals";
                pinkDcs[i].GetComponent<Collider2D>().enabled = true;
            }

            foreach (Transform child in inventory)
            {
                GameObject.Destroy(child.gameObject);
            }

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Check which Dreamcatcher to catch based on the Tag

        if (collision.CompareTag("DreamCatcherPurple"))
        {
            dc1.Play();
            var dc = Instantiate(imagePrefab, inventory);
            dc.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            hasPurpleKey = true;
            collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
           
        }

        if (collision.CompareTag("DreamCatcherGreen"))
        {
            dc2.Play();
            var dc = Instantiate(imagePrefab, inventory);
            dc.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            hasGreenKey = true;
            collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
        }

        if (collision.CompareTag("DreamCatcherPink"))
        {
            dc3.Play();
            var dc = Instantiate(imagePrefab, inventory);
            dc.GetComponent<Image>().sprite = collision.gameObject.GetComponent<SpriteRenderer>().sprite;
            hasPinkKey = true;
            collision.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Default";
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
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
