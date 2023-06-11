using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public VidaInimigos vida;
    public float maxVida;
    public Animator anim;
    private float meiaVida;

    public GameObject minerios;
    private bool meiaVidaMeteoro;
    private float vez=0;
    public respawnerMeteoro respawner;
    public AudioSource audio;
    public AudioClip[] audioClip;
    void Start()
    {
        vida.vida =maxVida;
        meiaVida = maxVida/2;
        respawner = GameObject.Find("RespawnerMeteoro").GetComponent<respawnerMeteoro>();
        anim.StopPlayback();
    }

    // Update is called once per frame
    void Update()
    {
        if(vida.vida<=0){
            meiaVidaMeteoro=false;
            minerio();
            vez=vez+1;
            anim.SetBool("Explosao",true);
            respawner.DestroyEnemy(gameObject);
        }
        if(vida.vida >0&&vida.vida<=meiaVida){
           meiaVidaMeteoro=true;
           anim.SetBool("meiaVida",meiaVidaMeteoro);
        }        
    }

    public void sonExplod(){
        audio.clip =audioClip[1];
        audio.Play();
    }
    void minerio(){
        if(vez==1){
            Instantiate(minerios,transform.position,Quaternion.identity);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag =="Bala"){
            if(vida.vida>0){
                audio.clip =audioClip[0];
                audio.Play();
            }
        }
    }
}
