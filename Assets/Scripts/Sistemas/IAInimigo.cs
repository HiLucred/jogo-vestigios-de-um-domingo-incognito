using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAInimigo : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public Transform alvo;
    public float velocidade;
    
    [Header("Atributos do Inimigo")]
    public int danoDoInimigo;
    public float velocidadeAtaque = 1f;
    
    [Header("Alvo Player")] 
    public GameObject jogador;
    
    //Som ao detectar o Player
    public AudioSource audioAtacar;
    
    //Adicionais
    private float podeAtacar;
    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (alvo != null)
        {
            SeguirAlvo();
        }
    }

    void SeguirAlvo()
    {
        transform.position = Vector2.Lerp(transform.position, 
            alvo.position, velocidade * Time.deltaTime);
    }
    
    // -- FAZ O JOGADOR PERDER VIDA -- //
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Vida>().Saude(danoDoInimigo);
            other.gameObject.GetComponent<Vida>().PiscarJogador();
        }
    }
    
    // -- FAZ O INIMIGO ATACAR O JOGADOR CONFORME A SUA RESPECTIVA VELOCIDADE DE ATAQUE -- //
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (velocidadeAtaque <= podeAtacar)
            {
                other.gameObject.GetComponent<Vida>().Saude(danoDoInimigo);
                other.gameObject.GetComponent<Vida>().PiscarJogador();
                podeAtacar = 0;
            }
            podeAtacar += Time.deltaTime;
        }
    }
    
    // -- FAZ O INIMIGO PERSEGUIR O JOGADOR -- //
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audioAtacar.Play();
            alvo = other.transform;
            sr.flipX = true;
        }
    }

    // -- FAZ O INIMIGO PARAR DE PERSEGUIR O JOGADOR -- //
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alvo = null;
        }
    }
    
}
