using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class CriaturaRoxa : MonoBehaviour
{
    
    [Header("Configurações")]
    private bool abrirDialogo;
    public float radius;
    public LayerMask layer;

    //Este Header faz o personagem se agachar para baixo
    [Header("Personagem se abaixar para conversar")]
    public float tempoDesejado;
    public Transform posicaoDesejada;
    
    //Aciona a interação de diálogo
    public Transform posicaoDialogo;

    void Update()
    {
        Dialogo();
    }

    void Dialogo()
    {
        
        abrirDialogo = Physics2D.OverlapCircle(posicaoDialogo.position, radius, layer);
        
        if (abrirDialogo)
        {
            transform.position = Vector3.Lerp(transform.position, posicaoDesejada.position, tempoDesejado * Time.deltaTime);
            Debug.Log("Abrir Dialogo");
        }
    }
    
}
