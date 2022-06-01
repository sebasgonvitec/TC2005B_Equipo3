/*
 Smooth camera movement following player during Maker Mode

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 13/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCamera : MonoBehaviour
{
    public new Camera camera;
    public GameObject player;
    public float offsetX;
    public float offsetY;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    public int speed;

    // Update is called once per frame
    void Update()
    {
        //Camera movement when in Test mode
        if (MakerMode.playMode)
        {
            camera.orthographicSize = 6;

            playerPosition = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

            if (player.transform.localScale.x > 0f)
            {
                playerPosition = new Vector3(playerPosition.x + offsetX, playerPosition.y + offsetY, playerPosition.z);
            }
            else
            {
                playerPosition = new Vector3(playerPosition.x - offsetX, playerPosition.y + offsetY, playerPosition.z);
            }

            transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime);
        }
        else //Camera movement when in Maker Mode
        {
            camera.orthographicSize = 10;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));
            }
        }
       
    }
}