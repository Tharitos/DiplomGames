using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_player : MonoBehaviour
{
    public int Speed;
    Vector3 LastPos;
    // Start is called before the first frame update
    void Start()
    {
        LastPos = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward*Speed*Time.deltaTime);
        RaycastHit hit;
        if(Physics.Linecast(LastPos,transform.position, out hit))
        {
            //print(hit.transform.name);
            //Destroy(gameObject);
        }
        LastPos = transform.position;
    }
}
