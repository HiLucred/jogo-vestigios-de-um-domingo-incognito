using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class VidaDoInimigo : MonoBehaviour
{
    [Header("Controle de Vida")]
    public int saudeMaxima = 100;
    public int saude;

    [Header("Ganhar Ponto ao Matar o Inimigo")]
    private PontuacaoInimigo pontoInimigo;
    //Ponto que deve ser coletado
    public int pontoGanho;
    
    [Header("Levar Dano no Personagem")]
    private SpriteRenderer sr;
    public Color cor;
    public Color corOriginal;

    [Header("Partículas de Dano/Morte")] 
    public ParticleSystem danoParticula;
    public GameObject morteParticula;
    
    //Sangue após o inimigo morrer
    public GameObject sangue;

    [Header("Efeitos Sonoros de Dano/Morte")]
    public AudioSource somDano;
    public GameObject somMorte;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        pontoInimigo = FindObjectOfType<PontuacaoInimigo>();
    }
    
    void Start()
    {
        saude = saudeMaxima;
    }
    
    public void Saude(int dano)
    {
        saude -= dano;
        ParticulaDano();
        SomDano();

        if(saude >= saudeMaxima)
        {
            saude = saudeMaxima;
        }else if(saude <= 0)
        {
            //Solta partícula de morte
            ParticulaMorte();
            
            //Som de morte
            SomMorte();
            
            //Adiciona ponto na HUD
            pontoInimigo.GanhouPonto(pontoGanho);

            //Sangue nos tiles
            Instantiate(sangue, transform.position, quaternion.identity);
            
            //Certifica que a saúde está zerada
            saude = 0;
            
            //Destroi o inimigo
            Destroy(gameObject);
        }
    }
    
    #region Particulas e Som
    
    // - PARTICULAS - //
        public void ParticulaDano()
        {
            danoParticula.Play();
        }

        public void ParticulaMorte()
        {
            Instantiate(morteParticula, transform.position, Quaternion.identity);
        }
        
    // - EFEITO SONORO - //
        public void SomDano()
        {
            somDano.Play();
        }

        public void SomMorte()
        {
            Instantiate(somMorte, transform.position, quaternion.identity);
        }
        
    #endregion

    #region Feedback de Dano
    
      // - FAZ O INIMIGO PISCAR AO LEVAR DANO - //
        public void Piscar()
        {
            StartCoroutine(PiscarDano());
        }
        IEnumerator PiscarDano()
        {
            sr.color = cor;
            yield return new WaitForSeconds(0.2f);
            sr.color = corOriginal;
            yield return new WaitForSeconds(0.2f);
            sr.color = cor;
            yield return new WaitForSeconds(0.2f);
            sr.color = corOriginal;
            yield return new WaitForSeconds(0.2f);
        }
        
    #endregion
    
  
}