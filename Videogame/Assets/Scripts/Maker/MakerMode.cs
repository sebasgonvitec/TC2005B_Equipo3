using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MakerMode : MonoBehaviour
{
    public MakerBlock[] blocks;
    public GameObject buttonPrefab;
    public Transform elementBar;

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
        for (int i = 0; i < blocks.Length; i++)
        {

            int u = i;

            var button = Instantiate(buttonPrefab, elementBar);
            button.GetComponent<Image>().sprite = blocks[i].blockSprite;
            button.GetComponent<Button>().onClick.AddListener(() =>
            {
                testSprite.sprite = blocks[u].blockSprite;
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

            if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.D))
            {
                var i = Physics2D.CircleCast(pos, 0.4f, Vector2.zero);
                if (i.collider == null)
                {
                    Instantiate(blocks[id], pos, Quaternion.identity);
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                testSprite.sprite = eraseSprite;
                if (Input.GetMouseButtonDown(0))
                {
                    var j = Physics2D.CircleCast(pos, 0.4f, Vector2.zero);
                    if (j.collider != null)
                    {
                        Debug.Log(j.collider.gameObject);
                        Destroy(j.collider.gameObject);
                    }
                }

            }
            testSprite.transform.position = pos;
     }
          

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
