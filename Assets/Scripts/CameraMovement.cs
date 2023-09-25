using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform Target; // Drag the object that will be followed in the inspector.
    public Transform Camera; // Drag the camera object in the inspector.
    Vector3 tempVec3 = new Vector3(); // Temporary vector 3.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the target is active in the scene, set the x camera position to target.
    if (Target != null)
    {
        tempVec3 = Target.position;
        this.transform.position = tempVec3;


        float LookY = Input.GetAxis("Mouse X");
        float LookX = Input.GetAxis("Mouse Y");


        this.transform.Rotate((LookX)*2 , (LookY)*2, 0, Space.World);
        Target.transform.Rotate((LookX)*2 , (LookY)*2, 0, Space.World);
    }
    }
}
