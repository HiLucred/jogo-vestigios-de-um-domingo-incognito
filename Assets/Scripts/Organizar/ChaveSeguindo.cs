using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveSeguindo : MonoBehaviour
{
    [Header("Parâmetros da Chave")]
    public float velocidade;
    public Transform alvo;
    private bool podeSeguir;

    [Header("Configurações")]
    public Controller jogador;

    void Start()
    {
        
    }

 
    void Update()
    {
        if (podeSeguir)
        {
            transform.position = Vector3.Lerp(transform.position, alvo.position, velocidade * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (!podeSeguir)
            {
                jogador = FindObjectOfType<Controller>();
                alvo = jogador.chave;
                podeSeguir = true;

                //Controller jogador = FindObjectOfType<Controller>();
                //alvo = jogador.chave;
                
                //podeSeguir = true;
                //jogador.chaveSeguindo = this;
            }
        }
    }

}
