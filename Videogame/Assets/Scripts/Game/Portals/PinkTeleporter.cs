/*
 Pink Portal functionality

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 15/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkTeleporter : MonoBehaviour
{
    public Transform destination;
    private GameObject[] portals;

    public void Update()
    {
        //Get destination portal
        destination = GetOtherPortal();
    }

    //Getter for destination of portal
    public Transform GetDestination()
    {
        return destination;
    }

    //Function to find other portal and store it in array
    public Transform GetOtherPortal()
    {
        //Stores Gameobjects with the tag PortalPink found in the scene
        portals = GameObject.FindGameObjectsWithTag("PortalPink");
        if (portals[1].transform.position != transform.position)
        {
            return portals[1].transform;
        }
        else
        {
            return portals[0].transform;
        }

    }
}