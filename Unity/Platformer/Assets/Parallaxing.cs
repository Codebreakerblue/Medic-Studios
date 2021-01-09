using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour{

    public Transform[] backgrounds;     //Array of baground and foregrounds for parallaxing
    private float[] parallaxScales;     //Proportion of camera movement
    public float smoothing = 1f;        //How smooth the parrallax will be. MUST be above 0

    private Transform cam;              //Reference to main camera transform
    private Vector3 previousCamPos;     //Position of camera in the previous frame


    //Awake is called before start. Great for references
    void Awake()
    {
        // set up camera reference
        cam = Camera.main.transform;
    }          

    // Start is called before the first frame update
    void Start()
    {
        // The previous frame had the current frames camera position
        previousCamPos = cam.position;  

        // Assigning parallax scales
        parallaxScales = new float[backgrounds.Length];
        for (int i= 0; i < backgrounds.Length; i++){
            parallaxScales[i] = backgrounds[i].position.z*-1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // for each background
        for (int i =0; i < backgrounds.Length; i++){
            // The parallax is the opposite of camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * parallaxScales[i];

            // set a target x position which is the current position plus the parallax
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;

            // Create a target position which is the background current position with its target x position
            Vector3 backgroundTargetPos = new Vector3 (backgroundTargetPosX, backgrounds[i].transform.position.y, backgrounds[i].transform.position.z);

            // Fade Between current position and target position with lerp
            backgrounds[i].transform.position = Vector3.Lerp (backgrounds[i].transform.position, backgroundTargetPos, smoothing* Time.deltaTime);
        }
        // Set previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
    }
}
