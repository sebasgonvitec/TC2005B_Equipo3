/*
 Script to manage the Maker Mode

 Sebasti�n Gonz�lez Villacorta - A01029746
 Karla Valeria Mondrag�n Rosas - A01025108
 Andre�na Isable San�nez Rico - A01024927

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

    //Drag objects blocks/UI
    public Transform blocksBar;
    public Transform portalsBar;
    public Transform doorsBar;
    public Transform decorationsBar;

    //Preview sprite
    public SpriteRenderer testSprite;

    int id;

    public Sprite eraseSprite;

    public static bool playMode; //if test mode is active
    public GameObject[] makerUI;
    public GameObject[] gameUI;

    private bool goalPlaced; // indicates if the end portal has been placed

    [SerializeField] private AudioSource placeBlockSound;
    [SerializeField] private AudioSource selectBlockSound;
    [SerializeField] private AudioSource deleteSound;
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
            // If block has id 0,1,2 or 3 place in blockbar
            if (blocks[u].id == 0 || blocks[u].id == 1 || blocks[u].id == 2 || blocks[u].id == 3) 
            {
                var button = Instantiate(buttonPrefab, blocksBar); // block/element button
                button.GetComponent<Image>().sprite = blocks[i].blockSprite; // place correspondig image
                
                // When clicking the button assign the current index to the variable id
                button.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (!selectBlockSound.isPlaying)
                    {
                        selectBlockSound.Play();
                    }
                    //Set block sprite to preview sprite
                    //testSprite.sprite = blocks[u].blockSprite;
                    //testSprite.transform.localScale = blocks[u].transform.localScale;
                    id = u;
                });
            }
            else if (blocks[u].id == 4 || blocks[u].id == 5 || blocks[u].id == 6 || blocks[u].id == 7 || blocks[u].id == 8 || blocks[u].id == 9)
            {
                var button = Instantiate(buttonPrefab, portalsBar);
                button.GetComponent<Image>().sprite = blocks[i].blockSprite;
                button.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (!selectBlockSound.isPlaying)
                    {
                        selectBlockSound.Play();
                    }
                    //Set block sprite to preview sprite
                    testSprite.sprite = blocks[u].blockSprite;
                    testSprite.transform.localScale = blocks[u].transform.localScale;
                    id = u;
                });
            }
            else if (blocks[u].id == 10 || blocks[u].id == 11 || blocks[u].id == 12 || blocks[u].id == 13)
            {
                var button = Instantiate(buttonPrefab, doorsBar);
                button.GetComponent<Image>().sprite = blocks[i].blockSprite;
                button.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (!selectBlockSound.isPlaying)
                    {
                        selectBlockSound.Play();
                    }
                    //Set block sprite to preview sprite
                    testSprite.sprite = blocks[u].blockSprite;
                    testSprite.transform.localScale = blocks[u].transform.localScale;
                    id = u;
                });
            }
            else if (blocks[u].id == 14 || blocks[u].id == 15 || blocks[u].id == 16)
            {
                var button = Instantiate(buttonPrefab, decorationsBar);
                button.GetComponent<Image>().sprite = blocks[i].blockSprite;
                button.GetComponent<Button>().onClick.AddListener(() =>
                {
                    if (!selectBlockSound.isPlaying)
                    {
                        selectBlockSound.Play();
                    }
                    //Set block sprite to preview sprite
                    testSprite.sprite = blocks[u].blockSprite;
                    testSprite.transform.localScale = blocks[u].transform.localScale;
                    id = u;
                });
            }
            //var button = Instantiate(buttonPrefab, elementBar);
            //button.GetComponent<Image>().sprite = blocks[i].blockSprite;
            //button.GetComponent<Button>().onClick.AddListener(() =>
            //{
            //    //Set block sprite to preview sprite
            //    testSprite.sprite = blocks[u].blockSprite;
            //    testSprite.transform.localScale = blocks[u].transform.localScale;
            //    id = u;
            //});

            GameObject.FindGameObjectWithTag("MainMusic").GetComponent<MainMusic>().StopMusic();
        }
    }

    void Update()
    {

       // Evaluate if mouse is on screen or playmode is active don't do anything
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
                    if (!placeBlockSound.isPlaying)
                    {
                        placeBlockSound.Play();
                    }
                
                    if (blocks[id].id == 3 && !goalPlaced) //Stops player from placing more than one goal portal
                    {
                        Instantiate(blocks[id], pos, Quaternion.identity);
                        goalPlaced = true;
                    }   
                    else if(blocks[id].id != 3)
                    {
                        Instantiate(blocks[id], pos, Quaternion.identity);
                    }
                    
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
                    if (j.collider != null && !j.collider.CompareTag("Player") && !j.collider.CompareTag("DefaultBlocks"))
                    {
                        if (!deleteSound.isPlaying)
                        {
                            deleteSound.Play();
                        }

                        if (j.collider.gameObject.CompareTag("PortalGoal"))
                        {
                            goalPlaced = false;
                            Destroy(j.collider.gameObject);
                        }
                        else
                        {
                            Destroy(j.collider.gameObject);
                        }
                        
                    }
                }

            }
            else
            {
                testSprite.sprite = blocks[id].blockSprite;
                testSprite.transform.localScale = blocks[id].transform.localScale;
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
