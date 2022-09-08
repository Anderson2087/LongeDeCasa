using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public int forcaEmX;
    public int forcaEmZ;
    public float velocidadeMaximaZ;
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.z < velocidadeMaximaZ){

            rb.AddForce(0, 0, forcaEmZ * Time.fixedDeltaTime);

        }

        //Debug.Log("Velocidade em Z: " + rb.velocity.z.ToString());

        if(Input.GetKey("a") == true){
            
            rb.AddForce(-forcaEmX * Time.fixedDeltaTime, 0, 0);

        }

        if(Input.GetKey("d") == true){

            rb.AddForce(forcaEmX * Time.fixedDeltaTime, 0, 0);

        }

    }

        void OnCollisionEnter(Collision collision){

        Debug.Log("Eu colidi com alguma coisa: " + collision.collider.name);

        if(collision.collider.CompareTag("Inimigo") == true){

            gameController.GameOver();

        }
        
    }

    private void OnTriggerEnter(Collider trigger){
        if (trigger.CompareTag("Planeta")){

            gameController.VencerJogo();
            
        }
    }


}
