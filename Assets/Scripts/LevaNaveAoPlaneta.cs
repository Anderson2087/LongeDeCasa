using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevaNaveAoPlaneta : MonoBehaviour
{
    public PlayerController player;
    public GameObject planeta;
    public SeguirJogador seguirJogador;
    public float forcaAoPlaneta = 1000;
    // Start is called before the first frame update
    void Start()
    {
        seguirJogador.enabled = false;
        player.enabled = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direcaoAoPlaneta = planeta.transform.position - player.transform.position;
        if(direcaoAoPlaneta.magnitude < 200.0f){

            this.enabled = false;
            player.rb.velocity = new Vector3(0, 0, 0);
            return;
        }
        direcaoAoPlaneta.Normalize();
        player.rb.AddForce(direcaoAoPlaneta * Time.fixedDeltaTime * forcaAoPlaneta);
    }

    public void LeveNaveAoPlaneta(){

        this.enabled = true;
        seguirJogador.enabled = false;
        player.enabled = false;

    }
}
