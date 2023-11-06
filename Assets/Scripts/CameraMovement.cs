using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform Target; // Drag the object that will be followed in the inspector.
    public Transform Camera; // Drag the camera object in the inspector.
    private Vector3 tempVec3 = new Vector3(); // Temporary vector 3.
    [SerializeField] private bool targeting;

    void Start()
    {
        targeting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out var _hit, Mathf.Infinity))
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                // Debug.Log("lock status:" + targeting);
                targeting = !targeting;
                // Debug.Log("lock status:" + targeting);
            }

        }

        if (targeting) 
        {
            transform.LookAt(_hit.transform);
        }

        // If the target is active in the scene, set the x camera position to target.
        if (Target != null)
        {
            tempVec3 = Target.position;
            Camera.transform.position = tempVec3;

            if (!targeting)
            {
                float LookY = Input.GetAxis("Mouse X");
                float LookX = Input.GetAxis("Mouse Y");

                Camera.transform.Rotate(LookX*-1, LookY, 0, Space.Self);
            }
            Target.transform.rotation = Camera.transform.rotation;
        }
    }
}
