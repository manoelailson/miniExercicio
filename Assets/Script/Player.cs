using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float speed;
    public GameObject bala;
    public Transform posBala;
    public Transform posBala2;
    public float fireRate;
    public float maxFireRate;
    public GameObject Propulsor;
    public Transform[] posCamera;
    public float maxGasolina;
    public float gasolinaAtual;

    public Image imgGasolina;

    public float damage;

    public Transform respaw;

    public float maxVida;
    public float vidaAtual;

    public Image imgVida;
    public GameObject[] navePropulsao;
    public GameObject[] propulsores;

    public Upgrade upgrade;

    public AudioSource audio;
    public AudioClip[] audioClip;
    public GameObject naveSumir;
    
    public static bool vivo=true;
    public AudioSource mainSon;

    private void Start() {
        gasolinaAtual=maxGasolina;  
        vidaAtual=maxVida;  
    }
    void Update() {
        if(vivo){
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);   

            Vector2 direction =  new Vector2(mousePos.x - transform.position.x,mousePos.y - transform.position.y); 

            transform.up = direction;

            MoveCharacter();
            Tiro();
            

            if(upgrade.lvspeed==0){
                navePropulsao[0].SetActive(true);
                Propulsor = propulsores[0];
            }
            if(upgrade.lvspeed==1){
                navePropulsao[0].SetActive(false);
                navePropulsao[1].SetActive(true);
                Propulsor = propulsores[1];
            }
            if(upgrade.lvspeed==2){
                navePropulsao[1].SetActive(false);
                navePropulsao[2].SetActive(true);
                Propulsor = propulsores[2];
            }
            if(upgrade.lvspeed==3){
                navePropulsao[2].SetActive(false);
                navePropulsao[3].SetActive(true);
                Propulsor = propulsores[3];
            }
       }
    }

    void MoveCharacter(){
        if(gasolinaAtual>0){
            if(Input.GetKey(KeyCode.W)){
                ConsumoGasolina();
                transform.Translate(0,speed*Time.deltaTime,0);
                Propulsor.SetActive(true);
            }else if(Input.GetKey(KeyCode.S)){
                ConsumoGasolina();
                transform.Translate(0,-speed*Time.deltaTime,0);
                Propulsor.SetActive(true);
            }else{
                Propulsor.SetActive(false);
            }
        }else{
            if(Input.GetKeyDown(KeyCode.R)){
                transform.position =respaw.position;
               RecarregaGasolina();
            }
            Propulsor.SetActive(false);
        }
        
    }

    void Tiro(){
        if(fireRate>0){
            fireRate -= Time.deltaTime;
        }else{
            if(Input.GetMouseButtonDown(0)){
                Instantiate(bala,posBala.position,transform.rotation);
                fireRate=maxFireRate;
                Instantiate(bala,posBala2.position,transform.rotation);
               
            }
            
        }
        
    }

    void ConsumoGasolina(){
        if(gasolinaAtual>0){
            gasolinaAtual -=  1 * Mathf.Abs(speed)* Time.fixedDeltaTime;
            imgGasolina.fillAmount = gasolinaAtual/maxGasolina; 
        }
        
    }

   public void DanoVida(float dano){
        if(vidaAtual>0){
            vidaAtual -=  dano;
            imgVida.fillAmount = vidaAtual/maxVida; 
            audio.clip =audioClip[0];
            audio.Play();
        }else if(vidaAtual<=0){
            audio.clip =audioClip[1];
            audio.Play();
            transform.GetComponent<Animator>().SetBool("Explosion",true);
            naveSumir.SetActive(false);
            mainSon.Pause();
        }
        
    }

    public void Destruir(){
        vivo=false;
        transform.tag="Untagged";
        transform.gameObject.layer=0;
        StartCoroutine(trocaCena());
    }



    IEnumerator trocaCena(){
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("GameOver");
    }
    public void RecuperaVida(float recupera){
        if(vidaAtual<= 200){
            vidaAtual +=  recupera;
            if(vidaAtual>maxVida){
                vidaAtual=maxVida;
            }
            imgVida.fillAmount = vidaAtual/maxVida;
        }
 
    }
    public void RecarregaGasolina(){
        gasolinaAtual= maxGasolina;
        imgGasolina.fillAmount = gasolinaAtual/maxGasolina;
    }
}
