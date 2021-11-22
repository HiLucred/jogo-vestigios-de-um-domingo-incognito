using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainelArmaTele : MonoBehaviour
{
    public GameObject painelTele;
    private Controller jogador;
    private bool painelAberto;
    void Start()
    {
        jogador = FindObjectOfType<Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        if (painelAberto)
        {
            if (Input.GetKey(KeyCode.X))
            {
                jogador.podeMover = true;
                jogador.podePular = true;
                Destroy(painelTele);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!painelAberto)
            {
                painelTele.SetActive(true);
                jogador.podeMover = false;
                jogador.podePular = false;
                jogador.animacao.SetBool("podeCorrer", false);
                painelAberto = true;
            }
        }
    }
}
