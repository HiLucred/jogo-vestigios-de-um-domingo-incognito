using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptMenu : MonoBehaviour
{
    public int nomeDaCena;

    public void MudarCena()
    {
        SceneManager.LoadScene(nomeDaCena);
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
