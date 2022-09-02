using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirJogador : MonoBehaviour
{
    public PlayerController playerController;
    public Vector3 distanciaProJogador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = playerController.transform.position + distanciaProJogador;
        
    }
}
