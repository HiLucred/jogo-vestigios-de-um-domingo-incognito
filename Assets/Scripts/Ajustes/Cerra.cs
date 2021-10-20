using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerra : MonoBehaviour
{
    [Header("Mover Cerra")]
    private Rigidbody2D rb;
    private float tempo;
    public float velocidade;
    public bool horizontal;
    
    [Header("Dano no Jogador")]
    public int dano;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        tempo += Time.deltaTime;

        if(tempo >= 4)
        {
            velocidade *= -1;
            tempo = 0;
        }

        if (horizontal)
        {
            rb.velocity = new Vector2(velocidade, rb.velocity.y);    
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, velocidade); 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Vida>().Saude(dano);
            other.gameObject.GetComponent<Vida>().PiscarJogador();
        }
    }
}
