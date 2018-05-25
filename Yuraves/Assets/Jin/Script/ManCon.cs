using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ManCon : MonoBehaviour 
{
    //温泉
    private GameObject Spring1;
    private GameObject Spring2;
    private GameObject Spring3;
    private GameObject Spring4;

    void Start()
    {
        //温泉
        Spring1 = GameObject.Find("HotSpring1");
        Spring2 = GameObject.Find("HotSpring2");
        Spring3 = GameObject.Find("HotSpring3");
        Spring4 = GameObject.Find("HotSpring4");
                       
    }
    
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "HotSpring1")
        {
            //画像切替
            this.Spring1.GetComponent<ChangeImage>().ChangeStateToHold();
            //当たり判定
            this.Spring1.GetComponent<BoxCollider2D>().enabled = false;
            //フラグを立てる
            ResetHotSpring.Flag1 = true;
            Debug.Log("温泉１に当たった");

        }else if(collision.gameObject.name == "HotSpring2")
        {
            //画像切替
            this.Spring2.GetComponent<ChangeImage>().ChangeStateToHold();
            //当たり判定
            this.Spring2.GetComponent<BoxCollider2D>().enabled = false;
            //フラグを立てる
            ResetHotSpring.Flag2 = true;
            Debug.Log("温泉2に当たった");

        }else if(collision.gameObject.name == "HotSpring3")
        {
            //画像切替
            this.Spring3.GetComponent<ChangeImage>().ChangeStateToHold();
            //当たり判定
            ResetHotSpring.Flag3 = true;
            //フラグを立てる
            this.Spring3.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("温泉3に当たった");

        }else if(collision.gameObject.name == "HotSpring4")
        {
            //画像切替
            this.Spring4.GetComponent<ChangeImage>().ChangeStateToHold();
            //当たり判定
            ResetHotSpring.Flag4 = true;
            //フラグを立てる
            this.Spring4.GetComponent<BoxCollider2D>().enabled = false;
            Debug.Log("温泉4に当たった");

        }
    }
}
