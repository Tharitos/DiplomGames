using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_Store : MonoBehaviour
{
    public GameObject Damage_Buy;
    
    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            Damage_Buy.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            Damage_Buy.SetActive(false);
        }
    }
}