using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loja : MonoBehaviour
{
    public int dinheiro=0;
    public GameObject TutoExplica;

    public GameObject lojaObjeto;

    public int ouro;
    public int ferro;
    public int bronze;

    public TMP_Text txtBronzeColetado;
    public TMP_Text txtFerroColetado;
    public TMP_Text txtOuroColetado;

    public TMP_Text txtBronzeValorVenda;
    public TMP_Text txtFerroValorVenda;
    public TMP_Text txtOuroValorVenda;
    private int valorVendaBronze;
    private int valorVendaferro;
    private int valorVendaOuro;

    public TMP_Text txtDinheiro;
    private Coleta coleta;
    private bool abrirLoja;
    void Start()
    {
        coleta = GameObject.Find("UI").GetComponent<Coleta>();
        dinheiro=10000;
    }

    // Update is called once per frame
    void Update()
    {
        if(abrirLoja){
            if(Input.GetKey(KeyCode.L)){
                lojaObjeto.SetActive(true);
                ouro = coleta.ouro;
                ferro = coleta.ferro;
                bronze = coleta.bronze;
                txtBronzeColetado.text ="X "+ bronze.ToString();
                txtFerroColetado.text ="X "+ ferro.ToString();
                txtOuroColetado.text ="X "+ ouro.ToString();
                txtDinheiro.text="$ "+dinheiro.ToString();
                ValorVenda();
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="Player"){
            TutoExplica.SetActive(true);
            abrirLoja=true;
        }  
    }

    private void OnTriggerExit2D(Collider2D other) {
       if(other.gameObject.tag=="Player"){
            TutoExplica.SetActive(false);
            abrirLoja=false;
        } 
    }
    
   /* private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
           
        }
    }*/

    public void ValorVenda(){
        valorVendaBronze = bronze*1;
        valorVendaferro = ferro*5;
        valorVendaOuro = ouro*15;
        txtBronzeValorVenda.text ="X "+ valorVendaBronze.ToString();
        txtFerroValorVenda.text ="X "+ valorVendaferro.ToString();
        txtOuroValorVenda.text ="X "+ valorVendaOuro.ToString();
    }


    public void Venda(string name){
        if(name=="b" && bronze>0){
           dinheiro += valorVendaBronze;
           bronze = 0; 
           coleta.bronze=0;
           txtBronzeColetado.text ="X "+ bronze.ToString();
           coleta.txtBronze.text= coleta.bronze.ToString()+"/"+coleta.maxCapacidade; 
        }
        if(name=="f" && ferro>0){
           dinheiro += valorVendaferro;
           ferro = 0; 
           coleta.ferro=0;
           txtFerroColetado.text ="X "+ ferro.ToString();
           coleta.txtFerro.text = coleta.ferro.ToString()+"/"+coleta.maxCapacidade; 
        }
        if(name=="o" && ouro>0){
           dinheiro += valorVendaOuro;
           ouro = 0; 
           coleta.ouro=0;
           txtOuroColetado.text ="X "+ ouro.ToString();
           coleta.txtOuro.text = coleta.ouro.ToString()+"/"+coleta.maxCapacidade; 
        }
        ValorVenda();          
        txtDinheiro.text = "$ " +dinheiro.ToString();
    }
    public void FecharLoja(){
        lojaObjeto.SetActive(false);
    }
}
