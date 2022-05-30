using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenTeleporter : MonoBehaviour
{
    public Transform destination;
    private GameObject[] portals;

    public void Update()
    {
        //if (MakerMode.playMode)
        //{
        //    destination = GetOtherPortal();
        //}
        destination = GetOtherPortal();
    }
    public Transform GetDestination()
    {
        //destination = portals[0].transform;
        return destination;
    }

    public Transform GetOtherPortal()
    {
        portals = GameObject.FindGameObjectsWithTag("PortalGreen");
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
