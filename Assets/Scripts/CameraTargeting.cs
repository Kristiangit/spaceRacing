using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTargeting : MonoBehaviour
{
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
            if(Input.GetKey(KeyCode.R))
            {
                targeting = !targeting;
            }

        }

        if (targeting) 
        {
            transform.LookAt(_hit.transform);
        }

    }
}
