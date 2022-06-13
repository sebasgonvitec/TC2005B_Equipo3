using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudio : MonoBehaviour
{
    [SerializeField] private AudioSource boxDragAudio;
    [SerializeField] private Rigidbody2D box;

    void Update()
    {
        if(Mathf.Abs(box.velocity.x) > 0.1f)
        {
            if (!boxDragAudio.isPlaying)
            {
                boxDragAudio.Play();

            }
        }
        else
        {
            boxDragAudio.Stop();
        }
    }
}
