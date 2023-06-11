using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerios : MonoBehaviour
{
    enum minerio{bronze,ferro,ouro};
    [SerializeField] minerio tipoMinerio;
    public int valor;
    private Coleta coleta;
    void Start()
    {
        coleta = GameObject.Find("UI").GetComponent<Coleta>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag=="Player"){
            if(tipoMinerio==minerio.bronze){
                if(coleta.maxCapacidade>=coleta.bronze){
                    coleta.bronze += valor;
                }
                coleta.txtBronze.text = coleta.bronze.ToString()+"/"+coleta.maxCapacidade; 
            }
            if(tipoMinerio==minerio.ferro){
                if(coleta.maxCapacidade>= coleta.ferro){
                    coleta.ferro+= valor;
                }
                coleta.txtFerro.text = coleta.ferro.ToString()+"/"+coleta.maxCapacidade; 
            }
            if(tipoMinerio==minerio.ouro){
                if(coleta.maxCapacidade>= coleta.ouro){
                    coleta.ouro += valor;
                }
                coleta.txtOuro.text = coleta.ouro.ToString()+"/"+coleta.maxCapacidade; 
            }
           
            Destroy(gameObject);
        }
    }
}
