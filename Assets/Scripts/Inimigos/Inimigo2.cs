using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo2 : MonoBehaviour
{
    [Header("Movimentação do Inimigo")]
    private Rigidbody2D rb;
    private bool inverter;
    public float velocidade;

    //Configurações para inverter
    public Transform pontoA;
    public Transform pontoB;
    public LayerMask layer;

    //Dano que o inimigo da no jogador
    public int dano;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movimento();
    }

    void Movimento()
    {
        rb.velocity = new Vector2(velocidade, rb.velocity.y);

        inverter = Physics2D.Linecast(pontoA.position, pontoB.position, layer);
        if (inverter)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            velocidade *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        { 
            
            collision.gameObject.GetComponent<Vida>().Saude(dano);
            collision.gameObject.GetComponent<Vida>().PiscarJogador();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f);
        
        }
    }

}
