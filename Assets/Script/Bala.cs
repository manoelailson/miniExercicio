using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField]float speed;
    public float dano;
    void Start()
    {
        dano = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().damage;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*Time.deltaTime*speed);
        Destroy(gameObject,2f);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag=="Enemy"){
            other.GetComponentInParent<Inimigo>().DanoVida(dano);
            Destroy(gameObject);
        }
    }
}
