using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaveVermelha : MonoBehaviour
{
    [Header("Parâmetros da Chave")]
    public float velocidade;
    public Transform alvo;
    private bool podeSeguir;

    [Header("Configurações")]
    public Controller jogador;

    void Update()
    {
        if (podeSeguir)
        {
            transform.position = Vector3.Lerp(transform.position, alvo.position, velocidade * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!podeSeguir)
            {
                jogador = FindObjectOfType<Controller>();
                alvo = jogador.chave;
                podeSeguir = true;
            }
        }
    }

}
