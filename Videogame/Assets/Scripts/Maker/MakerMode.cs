/*
 Script to manage the Maker Mode

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 14/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakerMode : MonoBehaviour
{
    //Array of blocks available
    public MakerBlock[] blocks;
    public GameObject buttonPrefab;
    public Transform elementBar;

    //Preview sprite
    public SpriteRenderer testSprite;
    int id;

    public Sprite eraseSprite;

    public static bool playMode;
    public GameObject[] makerUI;
    public GameObject[] gameUI;

    //First try of dynamic dreamcatcher menu
    //private List<GameObject> dreamCatchers = new List<GameObject>();
    //public Transform dreamCatcherInventory;
    //public GameObject dreamCatcherImage;

    void Start()
    {   
        //Generate side bar with all draggable elements
        for (int i = 0; i < blocks.Length; i++)
        {

            int u = i;

            var button = Instantiate(buttonPrefab, elementBar);
            button.GetComponent<Image>().sprite = blocks[i].blockSprite;
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                //Set block sprite to preview sprite
                testSprite.sprite = blocks[u].blockSprite;
                testSprite.transform.localScale = blocks[u].transform.localScale;
                id = u;
            });
        }
    }

    void Update()
    {
        //if (playMode)
        //{
        //    {
        //        dreamCatchers.Add(GameObject.FindGameObjectWithTag("DreamCatcherPurple"));
        //        Debug.Log(GameObject.FindGameObjectWithTag("DreamCatcherPurple"));
        //        //dreamCatchers.Add(GameObject.FindGameObjectWithTag(""));

        //        foreach (GameObject dc in dreamCatchers)
        //        {
        //            var image = Instantiate(dreamCatcherImage, dreamCatcherInventory);
        //            image.GetComponent<Image>().sprite = dc.GetComponent<Image>().sprite;
        //        }

        //    }
        //}

        if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject() || playMode)
            return;
        
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0;
            pos.x = Mathf.RoundToInt(pos.x);
            pos.y = Mathf.RoundToInt(pos.y);

            //Prevent elements from being placed on top of each other
            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.D))
            {
                var i = Physics2D.CircleCast(pos, 0.4f, Vector2.zero);
                if (i.collider == null)
                {
                    Instantiate(blocks[id], pos, Quaternion.identity);
                }
            }
            //Erase elements while pressing key
            else if (Input.GetKey(KeyCode.D))
            {
                testSprite.sprite = eraseSprite;
                testSprite.transform.localScale = new Vector3(1f, 1f, 0);
                if (Input.GetMouseButtonDown(0))
                {
                    var j = Physics2D.CircleCast(pos, 0.4f, Vector2.zero);
                    if (j.collider != null)
                    {
                        Destroy(j.collider.gameObject);
                    }
                }

            }
            //Move preview sprite around
            testSprite.transform.position = pos;
     }
          

    //Toggle playMode variable to enter and exit Test Mode in Maker
    public void TogglePlay()
    {
        playMode = !playMode;
        
        for(int i = 0; i < makerUI.Length; i++)
        {
            makerUI[i].SetActive(!playMode);
        }

        for (int i = 0; i < gameUI.Length; i++)
        {
            gameUI[i].SetActive(playMode);
        }
    }
}
