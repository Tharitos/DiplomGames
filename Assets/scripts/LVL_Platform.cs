using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL_Platform : MonoBehaviour
{
    public GameObject LVL;
    
    void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            LVL.SetActive(true);
        }
    }
    void OnTriggerExit(Collider col){
        if(col.tag == "Player"){
            LVL.SetActive(false);
        }
    }
}
