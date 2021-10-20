using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcionaPassarela : MonoBehaviour
{
    [Header("Habilitar Passarela")]
    public GameObject passarela;
    public Transform passarelaInicio;
    public Transform passarelaFinal;
    public float tempoAbrindo;
    private AudioSource som;

    [Header("Detectar Botão")]
    public LayerMask layer;
    private bool acionar;
    
    //Adicionais
    private InterativoJogador botao;

    private void Awake()
    {
        botao = FindObjectOfType<InterativoJogador>();
        som = GetComponent<AudioSource>();
    }

    private void Update()
    {
        acionar = Physics2D.OverlapBox(transform.position, new Vector2(0.5f, 0.5f), 0, layer);
        if (acionar)
        {
            if (Input.GetKey(KeyCode.E))
            {
                botao.botaoPressionado = true;
                passarela.transform.position = Vector2.Lerp(passarelaInicio.position, passarelaFinal.position, tempoAbrindo);
                som.Play();
            }
        }
    }
}
