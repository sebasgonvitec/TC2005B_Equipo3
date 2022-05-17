//Logic for teleporting 

// Sebastián González Villacorta
// A01029746
// Karla Valeria Mondragón Rosas
// A01025108

// 13/05/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerTeleport2 : MonoBehaviour
{
    private GameObject currentTeleporter;
    private PlayerKeys hasKeyScript;

    public bool playerHasKey;

    private void Start()
    {
        hasKeyScript = GetComponent<PlayerKeys>();
    }

    void Update()
    {

        playerHasKey = hasKeyScript.hasKey;

        if (Input.GetKeyDown(KeyCode.E) && playerHasKey)
        {
            if(currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
