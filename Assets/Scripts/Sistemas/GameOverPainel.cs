using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPainel : MonoBehaviour
{
    private Vida vidaDoJogador;
    public GameObject painelFimDeJogo;
    

    private void Awake()
    {
        vidaDoJogador = FindObjectOfType<Vida>();
    }

    private void Update()
    {
        if (vidaDoJogador.saude <= 0)
        {
            painelFimDeJogo.SetActive(true);
        }
    }

    public void ReiniciarJogo()
    {
        SceneManager.LoadScene(0);
    }
}
