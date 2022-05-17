//Key for portals functionality

// Sebastián González Villacorta
// A01029746
// Karla Valeria Mondragón Rosas
// A01025108

// 13/05/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerKeys : MonoBehaviour
{
    [SerializeField] Image key;
    CanvasGroup canvasGroup;
  
    public bool hasKey;
    
    void Start()
    {
        canvasGroup = key.GetComponent<CanvasGroup>();
        hasKey = false;

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Key"))
        {
            hasKey = true;
            canvasGroup.alpha = 1;
            Destroy(collision.gameObject);
        }
    }
}
