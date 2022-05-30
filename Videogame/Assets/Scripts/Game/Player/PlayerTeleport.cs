using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null && GetComponent<PlayerKeys>().GetPurpleKey() && currentTeleporter.CompareTag("PortalPurple"))
            {
                transform.position = currentTeleporter.GetComponent<PurpleTeleporter>().GetDestination().position;
            }
            if (currentTeleporter != null && GetComponent<PlayerKeys>().GetGreenKey() && currentTeleporter.CompareTag("PortalGreen"))
            {
                transform.position = currentTeleporter.GetComponent<GreenTeleporter>().GetDestination().position;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PortalPurple"))
        {
            Debug.Log("Entered Portal");
            currentTeleporter = collision.gameObject;
        }

        if (collision.CompareTag("PortalGreen"))
        {
            Debug.Log("Entered Portal");
            currentTeleporter = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PortalPurple"))
        {
            Debug.Log("Exited Portal");
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
        if (collision.CompareTag("PortalGreen"))
        {
            Debug.Log("Exited Portal");
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }


}
