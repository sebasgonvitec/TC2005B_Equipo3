/*
 Scprit to teleport player from one portal to the other    

 Sebasti�n Gonz�lez Villacorta - A01029746
 Karla Valeria Mondrag�n Rosas - A01025108
 Andre�na Isable San�nez Rico - A01024927

 16/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportPlay : MonoBehaviour
{
    private GameObject currentTeleporter;
    [SerializeField] private AudioSource teleportSound;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //Move player to position of other portal if currently of a portal and after getting the key
            if (currentTeleporter != null && GetComponent<PlayerKeysPlay>().GetPurpleKey() && currentTeleporter.CompareTag("PortalPurple"))
            {
                if (!teleportSound.isPlaying)
                {
                    teleportSound.Play();
                }
                transform.position = currentTeleporter.GetComponent<PurpleTeleporter>().GetDestination().position;
            }
            if (currentTeleporter != null && GetComponent<PlayerKeysPlay>().GetGreenKey() && currentTeleporter.CompareTag("PortalGreen"))
            {
                if (!teleportSound.isPlaying)
                {
                    teleportSound.Play();
                }
                transform.position = currentTeleporter.GetComponent<GreenTeleporter>().GetDestination().position;
            }
            if (currentTeleporter != null && GetComponent<PlayerKeysPlay>().GetPinkKey() && currentTeleporter.CompareTag("PortalPink"))
            {
                if (!teleportSound.isPlaying)
                {
                    teleportSound.Play();
                }
                transform.position = currentTeleporter.GetComponent<PinkTeleporter>().GetDestination().position;
            }
        }
    }


    //Set which Portal you are currently on
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PortalPurple"))
        {
            //Debug.Log("Entered Portal");
            currentTeleporter = collision.gameObject;
        }

        if (collision.CompareTag("PortalGreen"))
        {
            //Debug.Log("Entered Portal");
            currentTeleporter = collision.gameObject;
        }

        if (collision.CompareTag("PortalPink"))
        {
            //Debug.Log("Entered Portal");
            currentTeleporter = collision.gameObject;
        }
    }

    //Set current Portal to none if not touching portal anymore
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PortalPurple"))
        {
            //Debug.Log("Exited Portal");
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
        if (collision.CompareTag("PortalGreen"))
        {
            //Debug.Log("Exited Portal");
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
        if (collision.CompareTag("PortalPink"))
        {
            //Debug.Log("Exited Portal");
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }


}

