using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public GameObject pontoB;
    public float velocidade;
    
    private Rigidbody2D rb; 
    private bool colidiu;
    private bool subir;
    private bool descer;
    private Controller jogador;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jogador = FindObjectOfType<Controller>();
    }

    private void Update()
    {
        if (colidiu)
        {
            AcionaElevador();
            
        }

        if (subir)
        {
            if (Input.GetKey(KeyCode.E))
            {
                velocidade = 150f;
            }
        }else if (descer)
        {
            if (Input.GetKey(KeyCode.E))
            {
                velocidade = -150f;
            }
        }
        Debug.Log(jogador.podeMover);
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                jogador.podeMover = false;
                AcionaElevador();
            }
        }
    }
    

    void AcionaElevador()
    {
        
        rb.velocity = new Vector2(rb.velocity.x, velocidade * Time.fixedDeltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("CaixaDePulo"))
        {
            velocidade *= 0;
            colidiu = true;
            
            jogador.podeMover = true;
            
            subir = true;
            descer = false;
        }

        if (other.gameObject.CompareTag("Quebravel"))
        {
            velocidade *= 0;
            colidiu = true;
            
            jogador.podeMover = true;
            
            
            descer = true;
            subir = false;
        }
    }
    
    
}
