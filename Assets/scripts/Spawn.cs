using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject objEnemy;
    public GameObject objEnemy_2;
    public GameObject spawnZone;

    /*float max_x;
    float min_x;
    float max_z;
    float min_z;
    
    // Start is called before the first frame update
    void Start()
    {
        max_x = spawnZone.position.x + spawnZone.localScale.x/2;
        min_x = spawnZone.position.x - spawnZone.localScale.x/2;

        max_z = spawnZone.position.x + spawnZone.localScale.z/2;
        min_z = spawnZone.position.x - spawnZone.localScale.z/2;
    }*/

    // Update is called once per frame
    IEnumerator Start()
    //void Update()
    {
        if(Global_Script.Start_Wave){
            //Vector3 spawnZone = new Vector3(Random.Range(min_x,max_x), spawnZone.position.y, Random.Range(min_z,max_z));
            for(int i=0; i<Global_Script.Wave; i++){
                if(Global_Script.Wave > 4){
                    for(int i_1=2; i_1<(Global_Script.Wave/2); i_1++){
                        Instantiate(objEnemy_2, spawnZone.transform.position, Quaternion.identity);
                        Instantiate(objEnemy, spawnZone.transform.position, Quaternion.identity);
                        yield return new WaitForSeconds(15);
                }
            }
            yield return new WaitForSeconds(10);
            Instantiate(objEnemy, spawnZone.transform.position, Quaternion.identity);
            //yield return new WaitForSeconds(10);
            }
        }
    }

}
