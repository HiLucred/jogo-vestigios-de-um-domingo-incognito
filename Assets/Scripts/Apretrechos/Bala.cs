using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [Header("Física do Disparo da Bala")]
    public float velocidade;
    private Rigidbody2D rb;

    [Header("Configurações da Bala")]
    public int danoDaBala;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = transform.right * velocidade;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        //Se colidir com os Inimigos
        if (other.gameObject.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<VidaDoInimigo>().Saude(danoDaBala);
            other.gameObject.GetComponent<VidaDoInimigo>().Piscar();
            other.gameObject.GetComponent<IAInimigo>().alvo = other.gameObject.GetComponent<IAInimigo>().jogador.transform;
            Destroy(gameObject);
        }
        
        //Se colidir com o Cenario
        if (other.gameObject.CompareTag("Cenario"))
        {
            Destroy(gameObject);
        }
        
        //Se colidir com a Parede
        if (other.gameObject.CompareTag("Parede"))
        {
            Destroy(gameObject);
        }
        
        //Se colidir com objetos quebraveis
        if (other.gameObject.CompareTag("Quebravel"))
        {
            other.gameObject.GetComponent<BlocoQuebravel>().Saude(danoDaBala);
            Destroy(gameObject);
        }
    }

}