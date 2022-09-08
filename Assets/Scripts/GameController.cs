using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Declarando a pontuação;
    public Text textoPontuacao;
    //Declarando o player para cauculo da pontuação no decorer do jogo;
    public PlayerController player;
    //Declarando a possição inicial do Player;
    Vector3 posicaoInicial;
    //Declarando divisor da pontuação, para a mesma não ficar subindo descontroladamente;
    public float divisorDaPontuacao;
    //Criando função do painel de Game Over
    public GameObject painelGameOver;

    public GameObject painelVencerJogo;

    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distanciaPercorida = player.transform.position - posicaoInicial;
        float pontuacao = distanciaPercorida.z / divisorDaPontuacao;
        textoPontuacao.text = pontuacao.ToString("0");
    }

    public void GameOver(){

        painelGameOver.SetActive(true);

    }

    public void VencerJogo(){

        painelVencerJogo.SetActive(true);
        //RecaregarLevel();
    }

    public void RecaregarLevel(){
        //Responsavel por reiniciar o Jogo do começo;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
