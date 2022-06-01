/*
 Script to open and close doors with lever in Play Mode

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 26/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerPlay : MonoBehaviour
{
    //Create array of GameObjects with the doors
    private GameObject[] doors;
    private bool doorOpen;
    private bool onLever;

    public Sprite openSprite;
    public Sprite closeSprite;


    void Start()
    {
        //Get array of doors
        GetDoors();

        doorOpen = true;
        //First change to colliders of doors
        for (int i = 0; i < doors.Length; i++)
        {
            ToggleDoorCollider(doorOpen, doors[i].GetComponent<Collider2D>());
        }
        

    }

    void Update()
    {
        //Conditions to open doors
        if (Input.GetKeyDown(KeyCode.E) && onLever)
        {
            ToggleDoor();
            Debug.Log("Door Action");
            for (int i = 0; i < doors.Length; i++)
            {
                ToggleDoorCollider(doorOpen, doors[i].GetComponent<Collider2D>());
            }
        }
        
    }

    //Returns array of GameObjects with tag DoorPurple
    public void GetDoors()
    {
        doors = GameObject.FindGameObjectsWithTag("DoorPurple");
    }

    //Detect if player is on lever
    void OnTriggerEnter2D(Collider2D col)
    { 
        if (col.CompareTag("LeverPurple"))
        {
            onLever = true;
        }
    }

    //Detect if player is not on lever anymore
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("LeverPurple"))
        {
            onLever = false;
        }
    }

    //Toggle doorOpen variable
    private void ToggleDoor()
    {
        doorOpen = !doorOpen;
    }

    //Enables or disables colliders and changes sprite of doors based on bool variable
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
