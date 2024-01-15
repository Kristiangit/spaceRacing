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
            if (inactiveOutline) {
                inactiveOutline.gameObject.SetActive(false);
                activeOutline.gameObject.SetActive(false);
            }

            activeOutline = _hit.transform.GetChild(0).GetChild(0);
            inactiveOutline = _hit.transform.GetChild(0).GetChild(1);
            inactiveOutline.gameObject.SetActive(true);

            
            Vector3 screenPos = Camera.GetComponent<Camera>().WorldToScreenPoint(_hit.transform.position);
            Vector3 screenPos2 = Camera.GetComponent<Camera>().WorldToScreenPoint(_hit.transform.GetComponent<Renderer>().bounds.max);
            float radius = (screenPos2.x - screenPos.x)*2 + 150f;


            inactiveOutline.transform.position = screenPos;

            inactiveOutline.GetComponent<RectTransform>().sizeDelta = new Vector2(radius, radius);
            inactiveOutline.gameObject.SetActive(true);

            activeOutline.transform.position = screenPos;
            activeOutline.GetComponent<RectTransform>().sizeDelta = new Vector2(radius, radius);


            if(Input.GetKeyDown(KeyCode.R))
            {
                targeting = !targeting;
                // Debug.Log("lock status:" + targeting);
            }
            activeOutline.gameObject.SetActive(false);

        }
        else if (inactiveOutline)
        {
            inactiveOutline.gameObject.SetActive(false);
            activeOutline.gameObject.SetActive(false);
        }

        if (targeting) 
        {
            inactiveOutline.gameObject.SetActive(false);
            activeOutline.gameObject.SetActive(true);

            Vector3 lookDirection = Target.position - Camera.position;
            lookDirection.Normalize();

            Camera.rotation = Quaternion.Lerp(Camera.rotation, Quaternion.LookRotation(lookDirection), 0.1f * Time.deltaTime);

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
