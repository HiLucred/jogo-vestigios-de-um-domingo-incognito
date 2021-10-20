using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirDescobrimento : MonoBehaviour
{
    public GameObject painelDescobrimento;

    public void AbrirPainel()
    {
        bool ativo = painelDescobrimento.activeSelf;
        painelDescobrimento.SetActive(!ativo);
    }
}
