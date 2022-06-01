/*
 Script to manage simple animation of lever when activated

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 26/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverAction : MonoBehaviour
{
    private Animator leverAnimation;
    private bool onPlayer;
    private bool leverState;

    void Update()
    {
        leverAnimation = GetComponent<Animator>();

        //Same conditions as doors
        if (Input.GetKeyDown(KeyCode.E) && onPlayer)
        {
            LeverToggle();
            leverAnimation.SetBool("leverState", leverState);
        }
    }

    //Check if player is on lever
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            onPlayer = true;
        }
    }

    //Toggle leverState boolean variable
    private void LeverToggle()
    {
        leverState = !leverState;
    }


}
