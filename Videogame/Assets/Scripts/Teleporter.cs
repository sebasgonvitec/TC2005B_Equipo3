//Function for getting position of another portal

// Sebastián González Villacorta
// A01029746
// Karla Valeria Mondragón Rosas
// A01025108

// 13/05/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

    [SerializeField] private Transform destination;
    
    public Transform GetDestination()
    {
        return destination;
    }
}
