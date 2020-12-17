using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public GameObject CameraOrbitCenter;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        float scrollFactor = Input.GetAxis("Mouse ScrollWheel");

        if (scrollFactor != 0)
        {
            CameraOrbitCenter.transform.localScale = CameraOrbitCenter.transform.localScale * (1f - scrollFactor);
        }

    }
}
