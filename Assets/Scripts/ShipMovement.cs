using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float speed;
    public float Vspeed;
    private float MoveX;
    private float MoveZ;
    // private float second = 0f;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
 
    // Update is called once per frame
    void Update()
    {
        MoveX = (Input.GetAxis("Horizontal"))/20;
        MoveZ = (Input.GetAxis("Vertical"))/20;

        // if (second >= 1.0f)
        // {
        //     Debug.Log(MoveX);
        //     Debug.Log(MoveZ);
        //     second = 0f;
        // }
        // second += Time.deltaTime;
            



        rb.velocity = new Vector3((speed * MoveX) + rb.velocity.x, rb.velocity.y, (speed * MoveZ) + rb.velocity.z);


        if(Input.GetKey(KeyCode.Space)) // Up
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y + 0.03f, rb.velocity.z);
            }   


        if(Input.GetKey(KeyCode.LeftControl)) // Down
            {
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - 0.03f, rb.velocity.z);

            }   




        if(Input.GetKey(KeyCode.F))
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
    }
}

            
