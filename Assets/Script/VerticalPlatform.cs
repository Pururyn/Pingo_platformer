using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    public float Speed;
    public Transform child;
    public Transform parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        //Va faire des allers retour entre les 2 délimiteurs portant le tag "returnPlatform" si ça touche l'un des 2
        if (collision.CompareTag("returnPlatform")) 
        {
            Speed = -Speed;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {   
        //Quand le joueur (portant le tag "Player") interagi avec la plateforme, ça l'emporte avec
        if (collision.transform.CompareTag("Player"))
        {
            child.transform.SetParent(parent);
        }
    }
    private void OnCollisionExit2D(Collision2D collision) 
    {   
        //Quand le joueur sort de la platf, ça redevient normal
        if (collision.transform.CompareTag("Player"))
        {
            child.transform.SetParent(null);
        }
    }

    void Update()
    {   
        //Fait bouger la plateforme en fonction de la speed mis et le temps passé(x= 0, y = speed*time..., z = 0)
        transform.Translate(0, Speed * Time.deltaTime, 0); 
    }
}
