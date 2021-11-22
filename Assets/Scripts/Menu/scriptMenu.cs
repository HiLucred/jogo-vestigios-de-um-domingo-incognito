using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{
    public string nomeDaCena;

    public void MudarCena()
    {
        SceneManager.LoadScene(1);
    }
    
    public void VoltarMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Creditos()
    {
        SceneManager.LoadScene(2);
    }
    

    public void Sair()
    {
        Application.Quit();
    }
}
