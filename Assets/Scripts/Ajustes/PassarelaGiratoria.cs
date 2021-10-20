using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassarelaGiratoria : MonoBehaviour
{
    private float rotacaoZ;
    public float velocidadeDaRotacao;
    public bool antiHorarioRotacao;
    public float tempo;
    
    [Header("Parametros da Força do Dano")]
    public float forcaDoPulo;
    public int dano;

    void Update()
    {
         tempo += Time.deltaTime;

         if(tempo >= 6f)
         {
             antiHorarioRotacao = !antiHorarioRotacao;
             tempo = 0;
         }

         if (!antiHorarioRotacao)
         {
             rotacaoZ += -Time.deltaTime * velocidadeDaRotacao;
         }
         else
         {
             rotacaoZ += Time.deltaTime * 0;
         }

         transform.rotation = Quaternion.Euler(0, 0, rotacaoZ);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * forcaDoPulo, ForceMode2D.Impulse);
            other.gameObject.GetComponent<Vida>().Saude(dano);
            other.gameObject.GetComponent<Vida>().PiscarJogador();
        }
    }
}
