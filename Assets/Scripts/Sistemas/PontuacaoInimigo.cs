using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuacaoInimigo : MonoBehaviour
{
    [Header("HUD")]
    public Text pontuacaoTxt;

    [Header("Configurações")]
    [SerializeField] private int pontuacaoTotal;

    void Start()
    {
        pontuacaoTotal = 0; 
    }

    void Update()
    {
        pontuacaoTxt.text = pontuacaoTotal.ToString();
    }

    public void GanhouPonto(int ponto)
    {
        pontuacaoTotal += ponto;
    }
}
