using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public int forcaEmX;
    public int forcaEmZ;
    public float anguloAlvo = 30;
    public float velocidadeDeRotacao = 3;
    public float velocidadeMaximaZ;
    public GameController gameController;
    public GameObject fxExplosaoPrefab;

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

            Quaternion rotacaoAtual = rb.rotation;
            Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, anguloAlvo);
            Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDeRotacao);
            rb.MoveRotation(novaRotacao);

        } else if(Input.GetKey("d") == true){

            rb.AddForce(forcaEmX * Time.fixedDeltaTime, 0, 0);
            Quaternion rotacaoAtual = rb.rotation;
            Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, -anguloAlvo);
            Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDeRotacao);
            rb.MoveRotation(novaRotacao);

        } else {
            Quaternion rotacaoAtual = rb.rotation;
            Quaternion rotacaoAlvo = Quaternion.Euler(0, 0, 0);
            Quaternion novaRotacao = Quaternion.Lerp(rotacaoAtual, rotacaoAlvo, Time.fixedDeltaTime * velocidadeDeRotacao);
            rb.MoveRotation(novaRotacao);
        }

    }

        void OnCollisionEnter(Collision collision){

        if(collision.collider.CompareTag("Inimigo") == true){

            GameObject.Instantiate(fxExplosaoPrefab, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            gameController.GameOver();

        }
        
    }

    private void OnTriggerEnter(Collider trigger){
        if (trigger.CompareTag("Planeta")){

            gameController.VencerJogo();
            
        }
    }


}
