using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecarregaGasolina : MonoBehaviour
{
    private Player player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }


    private void OnTriggerStay2D(Collider2D other) {
        player.RecarregaGasolina();
    }
}
