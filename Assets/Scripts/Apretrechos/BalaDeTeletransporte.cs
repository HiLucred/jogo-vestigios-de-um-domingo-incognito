using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BalaDeTeletransporte : MonoBehaviour
{
    [Header("Física do Disparo da Bala de Teletransporte")]
    public float velocidade;
    private Rigidbody2D rb;

    [Header("Configurações da Bala")]
    //public int danoDaBala;
    
    //Referência do meu jogador
    private Controller jogador;

    [Header("Som da Colisão/Particula da Colisão")] 
    //Efeito sonoro
    public GameObject somTeletransportado;
    
    //Particula
    public GameObject particulaColisao;
    
    public Color cor;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jogador = FindObjectOfType<Controller>();
    }

    void Start()
    {
        rb.velocity = transform.right * velocidade;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Se colidir com a área de teletransporte
        if (other.gameObject.CompareTag("Teletransporte"))
        {
            Debug.Log("Colidiu");
            jogador.gameObject.transform.position = other.gameObject.transform.position;
            Instantiate(somTeletransportado, transform.position, quaternion.identity);
            Instantiate(particulaColisao, other.gameObject.transform.position, quaternion.identity);
            Destroy(gameObject);
        }
        
        //Se colidir com o Cenario
        if (other.gameObject.CompareTag("Cenario"))
        {
            Destroy(gameObject);
        }
    }

}
