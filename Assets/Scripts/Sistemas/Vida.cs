using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [Header("Controle de Vida")]
    public int saudeMaxima = 100;
    public int saude;
    public BarraDeVida barra;

    [Header("Particula de Sofrer Dano")]
    public ParticleSystem percaDeVida;

    [Header("Efeito Sonoro de Dano")] 
    public AudioSource somDano;

    [Header("Painel Fim de Jogo")] 
    public GameObject painelFimDeJogo;

    //Jogador pisca ao sofrer dano
    private SpriteRenderer sr;
    

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        saude = saudeMaxima;
        barra.saudeMaxima(saudeMaxima);
    }

    public void Saude(int dano)
    {
        saude -= dano;
        barra.setSaude(saude);
        percaDeVida.Play();
        somDano.Play();

        if(saude >= saudeMaxima)
        {
            saude = saudeMaxima;
        }else if(saude <= 0)
        {
            saude = 0;
            Destroy(gameObject,0.1f);
            Debug.Log("Fim de Jogo");
        }
    }

    
    public void PiscarJogador()
    {
        StartCoroutine(LevarDano());
    }

    IEnumerator LevarDano()
    {
        sr.color = new Color(1f,0f, 0f, 1f);
        yield return new WaitForSeconds(0.2f);
        sr.color = new Color(1f, 1f, 1f, 1f);
    }
}
