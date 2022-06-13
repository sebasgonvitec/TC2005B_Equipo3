/*
 Script to open and close doors with lever in Maker Mode

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 26/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    //Create array of GameObjects with the doors
    private GameObject[] doorsPurple;
    private GameObject[] doorsGreen;

    private bool doorOpenPurple;
    private bool doorOpenGreen;

    private bool onLeverPurple;
    private bool onLeverGreen;

    private bool doorsObtained;

    public Sprite openSpritePurple;
    public Sprite closeSpritePurple;

    public Sprite openSpriteGreen;
    public Sprite closeSpriteGreen;


    void Update()
    {
        if(MakerMode.playMode == false)
        {
            doorsObtained = false;
            doorOpenGreen = false;
            doorOpenPurple = false;
        }
        //On entering Test Mode...
        if (MakerMode.playMode)
        {
            //Only get doors and activate colliders once using state boolean
            if (!doorsObtained)
            {
                GetDoorsPurple();
                GetDoorsGreen();

                doorOpenPurple = true;
                for (int i = 0; i < doorsPurple.Length; i++)
                {
                    ToggleDoorColliderPurple(doorOpenPurple, doorsPurple[i].GetComponent<Collider2D>());
                }

                doorOpenGreen = true;
                for (int i = 0; i < doorsGreen.Length; i++)
                {
                    ToggleDoorColliderGreen(doorOpenGreen, doorsGreen[i].GetComponent<Collider2D>());
                }

                Debug.Log(doorsPurple.Length);
                Debug.Log(doorsGreen.Length);

                doorsObtained = true;
            }

            //Conditions to open doors
            if (Input.GetKeyDown(KeyCode.E) && onLeverPurple)
            {
                ToggleDoorPurple();
                Debug.Log("Purple Door Action");
                for (int i = 0; i < doorsPurple.Length; i++)
                {
                    ToggleDoorColliderPurple(doorOpenPurple, doorsPurple[i].GetComponent<Collider2D>());
                }
            }

            if (Input.GetKeyDown(KeyCode.E) && onLeverGreen)
            {
                ToggleDoorGreen();
                Debug.Log("Green Door Action");
                for (int i = 0; i < doorsGreen.Length; i++)
                {
                    ToggleDoorColliderGreen(doorOpenGreen, doorsGreen[i].GetComponent<Collider2D>());
                }
            }
        }
    }

    //Returns array of GameObjects with tag DoorPurple
    public void GetDoorsPurple()
    {
        doorsPurple = GameObject.FindGameObjectsWithTag("DoorPurple");
    }

    //Returns array of GameObjects with tag DoorGreen
    public void GetDoorsGreen()
    {
        doorsGreen = GameObject.FindGameObjectsWithTag("DoorGreen");
    }

    //Detect if player is on lever
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("LeverPurple"))
        {
            onLeverPurple = true;
        }
        if (col.CompareTag("LeverGreen"))
        {
            onLeverGreen = true;
        }
    }

    //Detect if player is not on lever anymore
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("LeverPurple"))
        {
            onLeverPurple = false;
        }
        if (col.CompareTag("LeverGreen"))
        {
            onLeverGreen = false;
        }
    }

    //Toggle doorOpen variable
    private void ToggleDoorPurple()
    {
        doorOpenPurple = !doorOpenPurple;
    }

    private void ToggleDoorGreen()
    {
        doorOpenGreen = !doorOpenGreen;
    }

    //Enables or disables colliders and changes sprite of doors based on bool variable
    public void ToggleDoorColliderPurple(bool doorOpen, Collider2D doorCollider)
    {
        doorCollider.enabled = doorOpen;
        for (int i = 0; i < doorsPurple.Length; i++)
        {
            if (!doorOpen)
            {
                doorsPurple[i].GetComponent<SpriteRenderer>().sprite = openSpritePurple;
            }
            else
            {
                doorsPurple[i].GetComponent<SpriteRenderer>().sprite = closeSpritePurple;
            }
        }
    }

    public void ToggleDoorColliderGreen(bool doorOpen, Collider2D doorCollider)
    {
        doorCollider.enabled = doorOpen;
        for (int i = 0; i < doorsGreen.Length; i++)
        {
            if (!doorOpen)
            {
                doorsGreen[i].GetComponent<SpriteRenderer>().sprite = openSpriteGreen;
            }
            else
            {
                doorsGreen[i].GetComponent<SpriteRenderer>().sprite = closeSpriteGreen;
            }
        }
    }
}