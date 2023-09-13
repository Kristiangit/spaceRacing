using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{

    public GameObject attractingBody;
    public GameObject attractedObject;

    private float second = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector3.Distance(attractedObject.transform.position, attractingBody.transform.position);
        // establish gravitational force based on 
        // gravity strength and distance between bodies
        // 1f is essentially your baseline gravity strength
        float g_constant = 2f;
        float mass_p = 10f;
        float mass_obj = 1f;

        float g_force = (g_constant * mass_p * mass_obj) / (distance*distance);






        // establish direction towards the attracting body
        Vector3 direction = attractingBody.transform.position - attractedObject.transform.position;

        // apply gravitational force of attraction to attracted body
        attractedObject.GetComponent<Rigidbody>().AddForce(direction.x * g_force, direction.y * g_force, direction.z * g_force, ForceMode.Impulse);    


        Debug.Log(distance);
        Debug.Log(g_force);
        if (second >= 1.0f)
        {
            Debug.Log(distance);
            Debug.Log(g_force);
            second = 0f;
        }
        second += Time.deltaTime;
    }
}
