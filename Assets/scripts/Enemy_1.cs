using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_1 : MonoBehaviour
{
    Animator animator;
    public GameObject player;
    public float dist;
    NavMeshAgent nav;
    public float Radius = 70;
    public float HP = 1f;
    //public GameObject Death;
    public float timeLeft = 10f;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP<0){
            //Instantiate(Death,transform.position, transform.rotation);
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            nav.enabled = false;
            timeLeft -= Time.deltaTime;
            if ( timeLeft < 0 ){
                Destroy (gameObject);
                Global_Script.money = Global_Script.money + 15;
            }    
        }
        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > Radius & dist>2f & HP>0)
        {
            nav.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }
        if (dist < Radius & HP>0)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("Run");
        }
        if (dist < 2f & HP>0)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.tag == "Bullet"){
            HP = HP - (0.1f * Global_Script.damage_player);
            //Debug.Log(Global_Script.armor);
        }
    }
}
