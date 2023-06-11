using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public Transform player;
    public float speed =5f;
    public GameObject bala;
    public Transform firePoint;
    public float timeDisparo=1.5f;
    public float timeMaxDisparo=1.5f;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private float distancia;
    public float distanciaPlayer;
    public float alvoDistancia;
    public float vidaAtual;
    public EnemyRespawner respawner;
    public AudioSource audio;
    public AudioClip[] audioClip;
    public GameObject naveSumir;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").gameObject.transform;
        respawner = GameObject.Find("ENemyGrupoSWpanner").GetComponent<EnemyRespawner>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(Player.vivo){
            if (IsPlayerInRange(distanciaPlayer))
            {
                TargetPlayer();
            }
            else
            {
                Patrol();
            }
        }
    }

    private void TargetPlayer(){
        distancia=Vector2.Distance(player.position,transform.position);
        Vector3  direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y,direction.x)*Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
        if(distancia >alvoDistancia){
            if(timeDisparo<=0){
                Fogo();
                timeDisparo=timeMaxDisparo;
            }else{
                timeDisparo-=Time.deltaTime;
            }
            MovePlayer(movement);
        }else{
            if(timeDisparo<=0){
                Fogo();
                timeDisparo=timeMaxDisparo;
            }else{
                timeDisparo-=Time.deltaTime;
            }
            
        }
    }

    private void Patrol(){
        //print("Patrulhando....");
    }
    private bool IsPlayerInRange(float range)
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer < range;
    }
    private void Fogo(){
        GameObject bullet = Instantiate(bala, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.velocity = firePoint.up * moveSpeed;
    }

    public void DanoVida(float dano){
        if(vidaAtual>0){
            vidaAtual -=  dano;
            audio.clip =audioClip[0];
            audio.Play();
        }else{
            audio.clip =audioClip[1];
            audio.Play();
            transform.localScale=new Vector3(8,8,1);
            respawner.DestroyEnemy(gameObject);
            transform.GetComponent<Animator>().SetBool("Explosion",true);
            naveSumir.SetActive(false);
        }
        
    }
    

    public void Destruir(){
        Destroy(gameObject);
    }

    void MovePlayer(Vector2 direction){
        rb.MovePosition((Vector2)transform.position+(direction*speed*Time.deltaTime));
    }
   
}