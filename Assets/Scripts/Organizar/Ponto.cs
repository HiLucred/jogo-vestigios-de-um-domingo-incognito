using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Ponto : MonoBehaviour
{
    [Header("Configura��es de Pontua��o")]
    public int pontoGanho;
    
    private AudioSource moedaColetada;
    
    public ParticleSystem particulaColetado;
    public GameObject particula;
    
    //Refer�ncia para a HUD
    private Pontuacao pontuacao;
    void Start()
    {
        pontuacao = FindObjectOfType<Pontuacao>();
        moedaColetada = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            moedaColetada.Play();
            Instantiate(particula, transform.position, quaternion.identity);
            //particulaColetado.Play();
            pontuacao.GanhouPonto(pontoGanho);
            Destroy(gameObject, 0.5f);
        }
    }
}
