using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private GameObject[] doors;
    private bool doorOpen;
    private bool onLever;
    private bool doorsObtained;

    public Sprite openSprite;
    public Sprite closeSprite;


    void Update()
    {
        if (MakerMode.playMode)
        {
            if (!doorsObtained)
            {
                GetDoors();

                doorOpen = true;
                for (int i = 0; i < doors.Length; i++)
                {
                    ToggleDoorCollider(doorOpen, doors[i].GetComponent<Collider2D>());
                }

                Debug.Log(doors.Length);

                doorsObtained = true;
            }

            if (Input.GetKeyDown(KeyCode.E) && onLever)
            {
                Debug.Log("Door Action");
                ToggleDoor();
                for (int i = 0; i < doors.Length; i++)
                {
                    ToggleDoorCollider(doorOpen, doors[i].GetComponent<Collider2D>());
                }
            }
        }
    }

    public void GetDoors()
    {
        doors = GameObject.FindGameObjectsWithTag("DoorPurple");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeverPurple"))
        {
            onLever = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("LeverPurple"))
        {
            onLever = false;
        }
    }

    private void ToggleDoor()
    {
        doorOpen = !doorOpen;
    }

    public void ToggleDoorCollider(bool doorOpen, Collider2D doorCollider)
    {
        doorCollider.enabled = doorOpen;
        for (int i = 0; i < doors.Length; i++)
        {
            if (!doorOpen)
            {
                doors[i].GetComponent<SpriteRenderer>().sprite = openSprite;
            }
            else
            {
                doors[i].GetComponent<SpriteRenderer>().sprite = closeSprite;
            }
        }
    }
}