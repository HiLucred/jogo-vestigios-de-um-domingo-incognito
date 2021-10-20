using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarrarObjetos : MonoBehaviour
{
    public Transform pegar;
    public Transform segurar;
    public float tamanhoDoRaio;
    public GameObject botaoE;
    public GameObject botaoE2;

    void Update()
    {
        RaycastHit2D detectou = Physics2D.Raycast(pegar.position, Vector2.right * transform.localScale, tamanhoDoRaio);
        if(detectou.collider != null && detectou.collider.CompareTag("CaixaDePulo"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                detectou.collider.gameObject.transform.parent = segurar;
                detectou.collider.gameObject.transform.position = segurar.position;
                detectou.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                botaoE.transform.rotation = Quaternion.Euler(0f,0f,0f);
                botaoE2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                botaoE.SetActive(false);
                botaoE2.SetActive(false);
            }
            else
            {
                detectou.collider.gameObject.transform.parent = null;
                detectou.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                botaoE.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                botaoE2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                botaoE.SetActive(true);
                botaoE2.SetActive(true);
            }
        }
    }
}
