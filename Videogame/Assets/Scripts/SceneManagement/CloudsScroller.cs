using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsScroller : MonoBehaviour
{
     RectTransform m_RectTransform;
     public float speed = 200f;

    // Start is called before the first frame update
    void Start()
    {
        //Fetch the RectTransform from the GameObject
        m_RectTransform = GetComponent<RectTransform>();   
    }

    // Update is called once per frame
    void Update()
    {
        m_RectTransform.anchoredPosition += new Vector2(speed * Time.deltaTime, 0); 

        if(m_RectTransform.anchoredPosition.x >= 1945)
            m_RectTransform.anchoredPosition = new Vector2(-1942, 0);

    }
}
