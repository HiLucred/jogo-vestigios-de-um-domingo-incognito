using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterativoJogador : MonoBehaviour
{
    public bool botaoPressionado;
    private Controller jogador;
    public GameObject botaoE;
    private void Awake()
    {
        jogador = FindObjectOfType<Controller>();
    }

    void Start()
    {
        botaoPressionado = false;
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            botaoE.transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            botaoE.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactive"))
        {
            botaoE.SetActive(true);
            if (botaoPressionado)
            {
                botaoE.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Interactive"))
        {
            botaoE.SetActive(false);
            botaoPressionado = false;
        }
    }
}
