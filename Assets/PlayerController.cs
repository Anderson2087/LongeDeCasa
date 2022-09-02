using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public int forcaEmX;
    public int forcaEmZ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forcaEmZ * Time.fixedDeltaTime);

        if(Input.GetKey("a") == true){
            
            rb.AddForce(-forcaEmX * Time.fixedDeltaTime, 0, 0);

        }

        if(Input.GetKey("d") == true){

            rb.AddForce(forcaEmX * Time.fixedDeltaTime, 0, 0);

        }

    }
}
