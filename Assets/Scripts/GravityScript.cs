using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{

    [SerializeField] private GameObject attractingBody;
    [SerializeField] private GameObject attractedObject;

    private float second = 0;
    [SerializeField] private float distance = 0;

    [SerializeField] private float g_constant = 9f;
    [SerializeField] private float mass_p = 50f;
    [SerializeField] private float mass_obj = 1f;

    [SerializeField] private float g_force = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        

        

        // establish gravitational force based on 
        // gravity strength and distance between bodies
        // 1f is essentially your baseline gravity strength



        // establish direction towards the attracting body
        // Vector3 direction = attractingBody.transform.position - attractedObject.transform.position;

        // apply gravitational force of attraction to attracted body
        // attractedObject.GetComponent<Rigidbody>().AddForce(direction.x * g_force, direction.y * g_force, direction.z * g_force, ForceMode.Impulse);    


        // Debug.Log(distance);
        // Debug.Log(g_force);

        if (second >= 1.0f)
        {
            // Debug.Log(distance);
            // Debug.Log(g_force);
            // second = 0f;
        }
        second += Time.deltaTime;
    }

    private void OnTriggerStay(Collider other) {
        if (other.CompareTag("Planet"))
        {
            distance = Vector3.Distance(attractedObject.transform.position, other.transform.position);
            g_force = (g_constant * mass_p * mass_obj) / (distance*distance);   

            // Debug.Log("trigger");
            Vector3 direction = other.transform.position - attractedObject.transform.position;

            attractedObject.GetComponent<Rigidbody>().AddForce(direction.x * g_force, direction.y * g_force, direction.z * g_force, ForceMode.Force);    
        }
    }
}
