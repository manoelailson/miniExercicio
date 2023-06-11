using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    private float damage=10;
    private float maxGasolina=10;
    private float maxFireRate=0.2f;
    private float speed;

    private float maxVida;
    private int maxCapacidade;
    private Loja loja;
    private Player player;

    //lvs de upgrade
    public int lvDamage;
    public int lvMaxVida;
    public int lvspeed;
    public int lvmaxgasolina;
    public int lvmaxfirerate;
    public int lvcapacidade;


    public int valorDamage=0;
    public int valorMaxVida;
    public int valorSpeed;
    public int valorGasolina;
    public int valorFirerate;
    public int ValorCapacidade;

    private bool abrirLoja;
    public GameObject TutoExplica;
    public GameObject lojaObjeto;



    public TMP_Text txtDinheiro;

    //parte da loja de damage
    public TMP_Text txtCompraDamage;
    public TMP_Text txtDemageNextLv;
    public TMP_Text txtValorUpDamage;
    public TMP_Text txtLvDamage;

    //parte max gasolina
    public TMP_Text txtCompraGasolina;
    public TMP_Text txtGasolinaNextLv;
    public TMP_Text txtValorUpGasolina;
    public TMP_Text txtLvGasolina;

    //parte firerate
    public TMP_Text txtCompraFirerate;
    public TMP_Text txtFirerateNextLv;
    public TMP_Text txtValorUpFirerate;
    public TMP_Text txtLvFirerate;

    //parte Speed
    public TMP_Text txtCompraSpeed;
    public TMP_Text txtSpeedNextLv;
    public TMP_Text txtValorUpSpeed;
    public TMP_Text txtLvSpeed;

    //parte maxvida
    public TMP_Text txtCompraMaxVida;
    public TMP_Text txtMaxVidaNextLv;
    public TMP_Text txtValorUpMaxVida;
    public TMP_Text txtLvMaxVida;

    //parte maxcapacidade
    public TMP_Text txtCompraCapacidade;
    public TMP_Text txtCapacidadeNextLv;
    public TMP_Text txtValorUpCapacidade;
    public TMP_Text txtLvCapacidade;

    public Coleta coleta;
    void Start()
    {
        loja = GameObject.Find("GrupoLoja").GetComponent<Loja>();
        player = GameObject.Find("Player").GetComponent<Player>();
        txtDinheiro.text="$ "+loja.dinheiro.ToString();
        Atualizar();
    }

    // Update is called once per frame
    void Update()
    {
         if(abrirLoja){
            if(Input.GetKey(KeyCode.L)){
                lojaObjeto.SetActive(true);
                
            }
        }
        
    }

    public void dinheiroAtualizar(){
        txtDinheiro.text="$ "+loja.dinheiro.ToString();
    }

    public void Atualizar(){
        txtCompraDamage.text = "Comprar";
        txtLvDamage.text= "LV: "+lvDamage.ToString();
        txtDemageNextLv.text = "+"+damage+" Damage";
        txtValorUpDamage.text = "$ "+valorDamage.ToString();

        // gasolina
        txtCompraGasolina.text = "Comprar";
        txtLvGasolina.text= "LV: "+lvmaxgasolina.ToString();
        txtGasolinaNextLv.text = "+"+maxGasolina+" Gasolina";
        txtValorUpGasolina.text = "$ "+valorGasolina.ToString();

        // firerate
        txtCompraFirerate.text = "Comprar";
        txtLvFirerate.text= "LV: "+lvmaxfirerate.ToString();
        txtFirerateNextLv.text = "+"+maxFireRate+" FireRate";
        txtValorUpFirerate.text = "$ "+valorFirerate.ToString();

        //speed
        txtCompraSpeed.text = "Comprar";
        txtLvSpeed.text= "LV: "+lvspeed.ToString();
        txtSpeedNextLv.text = "+"+speed+" Speed";
        txtValorUpSpeed.text = "$ "+valorSpeed.ToString();
        
        //maxVida
        txtCompraMaxVida.text = "Comprar";
        txtLvMaxVida.text= "LV: "+lvMaxVida.ToString();
        txtMaxVidaNextLv.text = "+"+maxVida+" Vida";
        txtValorUpMaxVida.text = "$ "+valorMaxVida.ToString();

        //maxCapacidade
        txtCompraCapacidade.text = "Comprar";
        txtLvCapacidade.text= "LV: "+lvcapacidade.ToString();
        txtCapacidadeNextLv.text = "+"+maxCapacidade+" Carga";
        txtValorUpCapacidade.text = "$ "+ValorCapacidade.ToString();

    }

    public void ComprarDamage(){
        if(loja.dinheiro >=valorDamage){
            if(lvDamage<4){
                if(lvDamage==0){
                    damage+=10;
                    loja.dinheiro -= valorDamage;  
                    dinheiroAtualizar();
                    valorDamage += 200;
                }else if(lvDamage==1){
                    damage+=20;
                    loja.dinheiro -= valorDamage;  
                    dinheiroAtualizar();
                    valorDamage += 200;
                }else if(lvDamage==2){
                    damage+=30;
                    loja.dinheiro -= valorDamage;  
                    dinheiroAtualizar();
                    valorDamage += 200;
                }else if(lvDamage==3){
                    damage+=40;
                    loja.dinheiro -= valorDamage;  
                    dinheiroAtualizar();
                    valorDamage += 200;
                    txtCompraDamage.text = "Max";
                    txtLvDamage.text= "LV: Max";
                    txtDemageNextLv.text ="Max";
                    txtValorUpDamage.text="Max";
                }
                player.damage=damage;
                lvDamage++;
                if(lvDamage<4){
                    txtLvDamage.text= "LV: "+lvDamage.ToString();
                    txtDemageNextLv.text = "+"+damage+" Damage";
                    txtValorUpDamage.text = "$ "+valorDamage.ToString();
                }
            }
        }
        
    }


    public void ComprarmaxGasolina(){
        if(loja.dinheiro >=valorGasolina){
            if(lvmaxgasolina<4){
                if(lvmaxgasolina==0){
                    maxGasolina+=10;
                    loja.dinheiro -= valorGasolina;  
                    dinheiroAtualizar();
                    valorGasolina+= 200;
                }else if(lvmaxgasolina==1){
                    maxGasolina+=20;
                    loja.dinheiro -= valorGasolina;  
                    dinheiroAtualizar();
                    valorGasolina += 200;
                }else if(lvmaxgasolina==2){
                    maxGasolina+=30;
                    loja.dinheiro -= valorGasolina;  
                    dinheiroAtualizar();
                    valorGasolina += 200;
                }else if(lvmaxgasolina==3){
                    maxGasolina+=40;
                    loja.dinheiro -= valorGasolina;  
                    dinheiroAtualizar();
                    valorGasolina += 200;
                    txtCompraGasolina.text = "Max";
                    txtLvGasolina.text= "LV: Max";
                    txtGasolinaNextLv.text ="Max";
                    txtValorUpGasolina.text="Max";
                }
                player.maxGasolina+=maxGasolina;
                lvmaxgasolina++;
                if(lvmaxgasolina<4){
                    txtLvGasolina.text= "LV: "+lvmaxgasolina.ToString();
                    txtGasolinaNextLv.text = "+"+maxGasolina+" Gasolina";
                    txtValorUpGasolina.text = "$ "+valorGasolina.ToString();
                }
            }
        }
    }

    public void ComprarmaxFireRate(){
         if(loja.dinheiro >=valorFirerate){
            if(lvmaxfirerate<4){
                if(lvmaxfirerate==0){
                    maxFireRate=0.2f;
                    loja.dinheiro -= valorFirerate;  
                    dinheiroAtualizar();
                    valorFirerate += 200;
                }else if(lvmaxfirerate==1){
                    maxFireRate=0.2f;
                    loja.dinheiro -= valorFirerate;  
                    dinheiroAtualizar();
                    valorFirerate = 200;
                }else if(lvmaxfirerate==2){
                    maxFireRate=0.4f;
                    loja.dinheiro -= valorFirerate;  
                    dinheiroAtualizar();
                    valorFirerate += 200;
                }else if(lvmaxfirerate==3){
                    maxFireRate=0.6f;
                    loja.dinheiro -= valorFirerate;  
                    dinheiroAtualizar();
                    valorFirerate += 200;
                    txtCompraFirerate.text = "Max";
                    txtLvFirerate.text= "LV: Max";
                    txtFirerateNextLv.text ="Max";
                    txtValorUpFirerate.text="Max";
                }
                player.maxFireRate-=maxFireRate;
                lvmaxfirerate++;
                if(lvmaxfirerate<4){
                    txtLvFirerate.text= "LV: "+lvmaxfirerate.ToString();
                    txtFirerateNextLv.text = "-"+maxFireRate+" FireRate";
                    txtValorUpFirerate.text = "$ "+valorFirerate.ToString();
                }
            }
        }
    }

    public void ComprarSpeed(){
        if(loja.dinheiro >=valorSpeed){
            if(lvspeed<4){
                if(lvspeed==0){
                    speed=0.5f;
                    loja.dinheiro -= valorSpeed;  
                    dinheiroAtualizar();
                    valorSpeed += 200;
                }else if(lvspeed==1){
                    speed=1f;
                    loja.dinheiro -= valorSpeed;  
                    dinheiroAtualizar();
                    valorSpeed = 200;
                }else if(lvspeed==2){
                    speed=1.5f;
                    loja.dinheiro -= valorSpeed;  
                    dinheiroAtualizar();
                    valorSpeed += 200;
                }else if(lvspeed==3){
                    speed=2f;
                    loja.dinheiro -= valorSpeed;  
                    dinheiroAtualizar();
                    valorSpeed += 200;
                    txtCompraSpeed.text = "Max";
                    txtLvSpeed.text= "LV: Max";
                    txtSpeedNextLv.text ="Max";
                    txtValorUpSpeed.text="Max";
                }
                player.speed +=speed;
                lvspeed++;
                if(lvspeed<4){
                    txtLvSpeed.text= "LV: "+lvspeed.ToString();
                    txtSpeedNextLv.text = "+"+speed+" Speed";
                    txtValorUpSpeed.text = "$ "+valorSpeed.ToString();
                }
            }
        }
    }

    public void ComprarMaxVida(){
        if(loja.dinheiro >=valorMaxVida){
            if(lvMaxVida<4){
                if(lvMaxVida==0){
                    maxVida=10;
                    loja.dinheiro -= valorMaxVida;  
                    dinheiroAtualizar();
                    valorMaxVida += 200;
                }else if(lvMaxVida==1){
                    maxVida=20;
                    loja.dinheiro -= valorMaxVida;  
                    dinheiroAtualizar();
                    valorMaxVida = 200;
                }else if(lvMaxVida==2){
                    maxVida=30;
                    loja.dinheiro -= valorMaxVida;  
                    dinheiroAtualizar();
                    valorMaxVida += 200;
                }else if(lvMaxVida==3){
                    maxVida=40;
                    loja.dinheiro -= valorMaxVida;  
                    dinheiroAtualizar();
                    valorMaxVida += 200;
                    txtCompraMaxVida.text = "Max";
                    txtLvMaxVida.text= "LV: Max";
                    txtMaxVidaNextLv.text ="Max";
                    txtValorUpMaxVida.text="Max";
                }
                player.maxVida +=maxVida;
                player.RecuperaVida(player.maxVida);
                lvMaxVida++;
                if(lvMaxVida<4){
                    txtLvMaxVida.text= "LV: "+lvMaxVida.ToString();
                    txtMaxVidaNextLv.text = "+"+maxVida+" Speed";
                    txtValorUpMaxVida.text = "$ "+valorMaxVida.ToString();
                }
            }
        }
    }

    public void ComprarMaxCapacidade(){
       if(loja.dinheiro >=ValorCapacidade){
            if(lvcapacidade<4){
                if(lvcapacidade==0){
                    maxCapacidade=100;
                    loja.dinheiro -= ValorCapacidade;  
                    dinheiroAtualizar();
                    ValorCapacidade += 200;
                }else if(lvcapacidade==1){
                    maxCapacidade=100;
                    loja.dinheiro -= ValorCapacidade;  
                    dinheiroAtualizar();
                    ValorCapacidade = 200;
                }else if(lvcapacidade==2){
                    maxCapacidade=100;
                    loja.dinheiro -= ValorCapacidade;  
                    dinheiroAtualizar();
                    ValorCapacidade += 200;
                }else if(lvcapacidade==3){
                    maxCapacidade=100;
                    loja.dinheiro -= ValorCapacidade;  
                    dinheiroAtualizar();
                    ValorCapacidade += 200;
                    txtCompraCapacidade.text = "Max";
                    txtLvCapacidade.text= "LV: Max";
                    txtCapacidadeNextLv.text ="Max";
                    txtValorUpCapacidade.text="Max";
                }
                coleta.maxCapacidade += maxCapacidade;
                coleta.txtBronze.text = coleta.bronze.ToString()+"/"+coleta.maxCapacidade; 
                coleta.txtFerro.text = coleta.ferro.ToString()+"/"+coleta.maxCapacidade; 
                coleta.txtOuro.text = coleta.ouro.ToString()+"/"+coleta.maxCapacidade; 
                lvcapacidade++;
                if(lvcapacidade<4){
                    txtLvCapacidade.text= "LV: "+lvcapacidade.ToString();
                    txtCapacidadeNextLv.text = "+"+maxCapacidade+" Carga";
                    txtValorUpCapacidade.text = "$ "+ValorCapacidade.ToString();
                }
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

    public void FecharLoja(){
        lojaObjeto.SetActive(false);
    }
}
