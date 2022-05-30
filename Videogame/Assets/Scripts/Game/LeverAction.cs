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

        if (Input.GetKeyDown(KeyCode.E) && onPlayer)
        {
            LeverToggle();
            leverAnimation.SetBool("leverState", leverState);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            onPlayer = true;
        }
    }

    private void LeverToggle()
    {
        leverState = !leverState;
    }


}
