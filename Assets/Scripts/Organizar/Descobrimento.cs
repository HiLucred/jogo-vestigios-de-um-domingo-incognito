using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Descobrimento : MonoBehaviour
{
    [Header("Configura o Descobrimento 1")]
    public Text descobriu;
    public Image imagemDescoberta;
    public GameObject atualizacao;

    [Header("Configuração de Descobrimento 2")]
    public Text descobriu2;
    public Image imagemDescoberta2;


    public void Pistas(string des, Sprite img)
    {
        atualizacao.SetActive(true);
        this.descobriu.text = des;
        this.imagemDescoberta.sprite = img;  
    }

    public void PistasDois(string des, Sprite img)
    {
        this.descobriu2.text = des;
        this.imagemDescoberta2.sprite = img;
    }
}