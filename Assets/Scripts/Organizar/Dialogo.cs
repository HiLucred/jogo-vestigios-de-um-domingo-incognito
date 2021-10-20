using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogo : MonoBehaviour
{
    [Header("Caixa de Diálogo")] public GameObject painelDeDialogo;
    public Image fotoDoPersonagem;
    public TextMeshProUGUI nomeDoFalante;
    public TextMeshProUGUI dialogo;

    [Header("Configurações")] 
    public float velocidadeParaDigitar;
    private string[] sentences;
    private int index;

    public void ChamarDialogo(Sprite fotoDoPersonagem, string nomeDoFalante, string[] dialogo)
    {
        painelDeDialogo.SetActive(true);
        this.fotoDoPersonagem.sprite = fotoDoPersonagem;
        this.nomeDoFalante.text = nomeDoFalante;
        sentences = dialogo;
        StartCoroutine(Digitando());
    }

    IEnumerator Digitando()
    {
        foreach(char letras in sentences[index].ToCharArray())
        {
            dialogo.text += letras;
            yield return new WaitForSeconds(velocidadeParaDigitar);
        }
    }

    public void ProximoDialogo()
    {
        if (dialogo.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                dialogo.text = "";
                StartCoroutine(Digitando());
            }
            else
            {
                dialogo.text = "";
                index = 0;
                painelDeDialogo.SetActive(false);
            }
        }
    }
}
