using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigos : MonoBehaviour
{
    public float vida;
    private Player player;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag=="Bala"){
            vida -= player.damage;
            Destroy(other.gameObject);
        }        
    }

    
}
