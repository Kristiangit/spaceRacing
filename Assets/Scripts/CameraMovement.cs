using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform Target; // Drag the object that will be followed in the inspector.
    public Transform Camera; // Drag the camera object in the inspector.
    [SerializeField] private bool targeting;
    private Transform activeOutline;
    private Transform inactiveOutline;

    void Start()
    {
        targeting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, transform.forward, out var _hit, Mathf.Infinity))
        {
            activeOutline = _hit.transform.GetChild(0).GetChild(0);
            inactiveOutline = _hit.transform.GetChild(0).GetChild(1);
            inactiveOutline.gameObject.SetActive(true);

            if(Input.GetKeyDown(KeyCode.R))
            {
                targeting = !targeting;
                // Debug.Log("lock status:" + targeting);
            }
            activeOutline.gameObject.SetActive(false);
        }
        else
        {
            inactiveOutline.gameObject.SetActive(false);
            activeOutline.gameObject.SetActive(false);
        }

        if (targeting) 
        {
            inactiveOutline.gameObject.SetActive(false);
            activeOutline.gameObject.SetActive(true);

            transform.LookAt(_hit.transform);


            // Vector3 screenPos = Camera.GetComponent<Camera>().WorldToScreenPoint(_hit.transform.position);
            // Vector3 screenPos2 = Camera.GetComponent<Camera>().WorldToScreenPoint(_hit.transform.GetComponent<Renderer>().bounds.max);
            // float radius = (screenPos2.x - screenPos.x)/100 + 1f;

            // activeOutline.transform.scale.x = radius;
            // activeOutline.transform.scale.y = radius;
            // activeOutline.transform.scale.z = radius;
        }

        // If the target is active in the scene, set the x camera position to target.
        if (Target != null)
        {
            Camera.transform.position = Target.position;

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
