using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_player : MonoBehaviour
{
    public Transform Bullet;
    public Transform Spawn;
    //public int Ammo = Global_Script.Ammo;
    public AudioClip Fire;
	public AudioClip Reload;
    public GameObject Fire_Image;
    // Start is called before the first frame update
    void Start()
    {
        Fire_Image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown (0)& Global_Script.Ammo > 0)
        if (Input.GetKeyDown(KeyCode.Q)& Global_Script.Ammo > 0)
        {
            Fire_Image.SetActive(true);
            Instantiate(Bullet, Spawn.position, Spawn.rotation);
            Global_Script.Ammo=Global_Script.Ammo-1;
            GetComponent<AudioSource> ().PlayOneShot (Fire);
        }
        if (Input.GetKeyDown (KeyCode.R) & Global_Script.Ammo < 10 ) {
			Global_Script.Ammo = 10;
            GetComponent<AudioSource> ().PlayOneShot (Reload);
		}
        //if (Input.GetMouseButtonUp(0)){
        if (Input.GetKeyUp(KeyCode.Q)){
            Fire_Image.SetActive(false);
        }
    }
}
