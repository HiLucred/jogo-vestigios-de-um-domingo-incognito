using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitaDescobrimento : MonoBehaviour
{
    public GameObject painelDescobrimento;
    private bool ativo;

    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            ativo = painelDescobrimento.activeSelf;
            StartCoroutine(Abrir());
            
        }
    }

    IEnumerator Abrir()
    {
        yield return new WaitForSeconds(0.2f);
        painelDescobrimento.SetActive(!ativo);
    }
}
