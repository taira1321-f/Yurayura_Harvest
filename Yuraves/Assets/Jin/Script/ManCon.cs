using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManCon : MonoBehaviour 
{
    //温泉
    private GameObject HotSpring1;
    private GameObject HotSpring2;
    private GameObject HotSpring3;
    private GameObject HotSpring4;
    //マンドラゴラ
    private GameObject Mandoragora;

    private GameObject TimeOut;

	public enum SpringType{
		Hot1,
		Hot2,
		Hot3,
		Hot4,
	}
    public SpringType springType;

    void Start()
    {
        //温泉
        HotSpring1 = GameObject.Find("HotSpring1");
        HotSpring2 = GameObject.Find("HotSpring2");
        HotSpring3 = GameObject.Find("HotSpring3");
        HotSpring4 = GameObject.Find("HotSpring4");
        //マンドラゴラ
        Mandoragora = GameObject.Find("Mandoragora");
        //フラグ管理
        //Flag = GameObject.Find("FlagManager");
        TimeOut = GameObject.Find("TimeController");
    }
    
    void Update()
    {
        if (FlagManager.Flag1 == true && FlagManager.Flag2 == true && FlagManager.Flag3 == true && FlagManager.Flag4 == true)
        {
            Debug.Log("４つ埋まった");

            this.HotSpring1.GetComponent<BoxCollider2D>().isTrigger = false;
            this.HotSpring2.GetComponent<BoxCollider2D>().isTrigger = false;
            this.HotSpring3.GetComponent<BoxCollider2D>().isTrigger = false;
            this.HotSpring4.GetComponent<BoxCollider2D>().isTrigger = false;

        }
    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "HotSpring1")
        {
            springType = SpringType.Hot1;
            FlagManager.Flag1 = true;
            this.HotSpring1.GetComponent<BoxCollider2D>().isTrigger = true;

        }else if(collision.gameObject.name == "HotSpring2")
        {
            springType = SpringType.Hot2;
            FlagManager.Flag2 = true;
            this.HotSpring2.GetComponent<BoxCollider2D>().isTrigger = true;

        }else if(collision.gameObject.name == "HotSpring3")
        {
            springType = SpringType.Hot3;
            FlagManager.Flag3 = true;
            this.HotSpring3.GetComponent<BoxCollider2D>().isTrigger = true;

        }
        else if(collision.gameObject.name == "HotSpring4")
        {
            springType = SpringType.Hot4;
            FlagManager.Flag4 = true;
            this.HotSpring4.GetComponent<BoxCollider2D>().isTrigger = true;
        }

        switch(springType){

            case SpringType.Hot1:                             
                //Destroy(this.Mandoragora);
                Debug.Log("温泉１に当たった");
                break;
            case SpringType.Hot2:
                //Destroy(this.Mandoragora);
                Debug.Log("温泉2に当たった");
                break;
            case SpringType.Hot3:
                //Destroy(this.Mandoragora);
                Debug.Log("温泉3に当たった");
                break;
            case SpringType.Hot4:
                //Destroy(this.Mandoragora);
                Debug.Log("温泉4に当たった");
                break;

        }

    }
}
