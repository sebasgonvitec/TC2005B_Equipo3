using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraPlay : MonoBehaviour
{
    public new Camera camera;
    public GameObject player;
    public float offsetX;
    public float offsetY;
    public float offsetSmoothing;
    private Vector3 playerPosition;

    public int speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
}
