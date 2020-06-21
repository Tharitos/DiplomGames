using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor_Store : MonoBehaviour
{
    public GameObject Armor_Buy;
    
    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            Armor_Buy.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            Armor_Buy.SetActive(false);
        }
    }
}