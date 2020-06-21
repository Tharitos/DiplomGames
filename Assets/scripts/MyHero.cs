using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHero : MonoBehaviour
{
    public float speed = 5.0f;//бег
    public float jumpS = 6.0f;//прыжок(мб не нужен)
    public float grav = 15.0f;//гравитация
    public Image UIHP;
    public Image UIHP_1;
    public float HP = Global_Script.HP_player;
    private Vector3 move_ = Vector3.zero;//движение
    private CharacterController controller;//обращение к контроллеру
    public Text Money;
    public Text Money_1;
    public Text Armor;
    public Text Damage;
    public Text Ammo;
    public Text Ammo_1;

    void Start()
    {
       controller = GetComponent<CharacterController>(); 
    }
    // Update is called once per frame
    void Update()
    {
        UIHP.fillAmount = HP;
        UIHP_1.fillAmount = HP;
        Money.text = ""+Global_Script.money;
        Money_1.text = ""+Global_Script.money;
        Ammo.text = ""+Global_Script.Ammo;
        Ammo_1.text = ""+Global_Script.Ammo;
        //Money.text = ""+Global_Script.Wave;
        Damage.text = ""+Global_Script.damage_player;
        Armor.text = ""+Global_Script.armor;
        if(HP<0){
            Global_Script.Game_On = false;
            Application.LoadLevel(0);
            Global_Script.money = Global_Script.Start_money;
            Global_Script.damage_player = 1;
            Global_Script.armor = 1;
            Global_Script.Wave = 1;
        }
        if (controller.isGrounded)
        {
            move_ = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            move_ = transform.TransformDirection(move_);
            move_ *=speed;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& controller.isGrounded)
        {
            move_.y = jumpS;
        }
        move_.y -= grav * Time.deltaTime;
        controller.Move(move_*Time.deltaTime);
    }
    void OnTriggerStay(Collider other){
        if(other.tag == "Dead"){
            HP -=Time.deltaTime;
        }
        if(other.tag == "Water"){
            HP -=Time.deltaTime*100f;
        }
        if(other.tag == "HP"){
            if(Input.GetKeyDown(KeyCode.F)){
                if((HP != Global_Script.Max_HP_player) && (Global_Script.money > 50)){
                    HP = Global_Script.Max_HP_player;
                    Global_Script.money = Global_Script.money - 50;
                }
            }
        }
        if(other.tag == "LVL"){
            if(Input.GetKeyDown(KeyCode.F)){
                if(Global_Script.Start_Wave != true){
                   Global_Script.Start_Wave = true;
                   //Global_Script.Wave = Global_Script.Wave + 1;
                }
                if(Global_Script.Start_Wave){
                   //Global_Script.Start_Wave = true;
                   Global_Script.Wave = Global_Script.Wave + 1;
                }
            }
        }
        if(other.tag == "Damage"){
            if(Input.GetKeyDown(KeyCode.F)){
                if(Global_Script.money > (50*Global_Script.damage_player) && Global_Script.damage_player < 10){
                    Global_Script.damage_player = Global_Script.damage_player + 1;
                    Global_Script.money = Global_Script.money - (50*Global_Script.damage_player);
                }
            }
        }
        if(other.tag == "Armor"){
            if(Input.GetKeyDown(KeyCode.F)){
                if(Global_Script.money > (50*Global_Script.armor) && Global_Script.armor < 10){
                    Global_Script.armor = Global_Script.armor + 1;
                    Global_Script.money = Global_Script.money - (50*Global_Script.armor);
                }
            }
        }
    }
    void OnTriggerEnter(Collider other){
        if (other.tag == "Enemy_1_damage"){
            HP = HP - (0.1f-(0.005f * Global_Script.armor));
        }
        if (other.tag == "Enemy_2_damage"){
            HP = HP - (0.2f-(0.01f * Global_Script.armor));
        }
        
    }
}
