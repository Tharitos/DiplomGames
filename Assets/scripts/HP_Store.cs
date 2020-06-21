using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_Store : MonoBehaviour
{
    public GameObject HP_Buy;
    
    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            HP_Buy.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            HP_Buy.SetActive(false);
        }
    }
}