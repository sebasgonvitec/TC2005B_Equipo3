/*
 Alternative smooth camera script

 Sebastián González Villacorta - A01029746
 Karla Valeria Mondragón Rosas - A01025108
 Andreína Isable Sanánez Rico - A01024927

 13/05/2022
 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    [SerializeField] Vector3 minValues, maxValues;

    [Range(1, 10)]
    [SerializeField] float smoothFactor;

    public int MakerCameraSpeed;
    private void Start()
    {
        transform.position = new Vector3(-24.08f, -17.67f, -10f);
    }
    private void FixedUpdate()
    {
        //Camera control in PlayMode
        if (MakerMode.playMode)
        {
            Camera.current.orthographicSize = 6;

            Vector3 targetPosition = target.position + offset;
            Vector3 boundPosition = new Vector3(
                Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
                Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
                Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));

            transform.position = boundPosition;
        }
        else //Camera control in MakerMode
        {
            Camera.current.orthographicSize = 10;

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(MakerCameraSpeed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-MakerCameraSpeed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -MakerCameraSpeed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, MakerCameraSpeed * Time.deltaTime, 0));
            }
        }
        
    }
}
