using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public int Speed = 10;
    public GameObject CameraTarget;

    void Update()
    {
        

    }

    void CameraTargetControl()
    {

    }

    void CameraClickDragControl()
    {
        //get input axes
        float xAxisValue = Input.GetAxis("Horizontal") * Speed;
        float zAxisValue = Input.GetAxis("Vertical") * Speed;

        transform.position = new Vector3(transform.localPosition.x + xAxisValue, transform.localPosition.y, transform.localPosition.z + zAxisValue);
    }