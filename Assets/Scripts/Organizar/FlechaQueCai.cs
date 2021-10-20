using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaQueCai : MonoBehaviour
{
    private TargetJoint2D tj;
    public int danoDaFlecha;

    private void Start()
    {
        tj = GetComponent<TargetJoint2D>();
    }

    void CairFlecha()
    {
        tj.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Invoke("CairFlecha", 0.5f);
            collision.gameObject.GetComponent<Vida>().Saude(danoDaFlecha);
            Destroy(gameObject, 3f);
        }
    }
}
