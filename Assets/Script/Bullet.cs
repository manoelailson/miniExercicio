using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dano = 10f;
    private Vector3 direction;

    private void Update()
    {
        // Move o projétil na direção e velocidade definidas
       // transform.Translate(Vector3.up*Time.deltaTime*speed);
        Destroy(gameObject,2f);
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"){
            collision.gameObject.GetComponent<Player>().DanoVida(dano);
            Destroy(gameObject);
        }
    }
}
