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
        Spring1 = GameObject.Find("HotSpring1");
        Spring2 = GameObject.Find("HotSpring2");
        Spring3 = GameObject.Find("HotSpring3");
        Spring4 = GameObject.Find("HotSpring4");
                
    }
    
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D collision) 
    {
        if(collision.gameObject.name == "HotSpring1")
        {
            springType = SpringType.Hot1;
            this.Spring1.GetComponent<ChangeImage>().ChangeStateToHold();


        }else if(collision.gameObject.name == "HotSpring2")
        {
            springType = SpringType.Hot2;
            this.Spring2.GetComponent<ChangeImage>().ChangeStateToHold();
            

        }else if(collision.gameObject.name == "HotSpring3")
        {
            springType = SpringType.Hot3;
            this.Spring3.GetComponent<ChangeImage>().ChangeStateToHold();
            
        }
        else if(collision.gameObject.name == "HotSpring4")
        {
            springType = SpringType.Hot4;
            this.Spring4.GetComponent<ChangeImage>().ChangeStateToHold();
           
        }

        switch(springType){

            case SpringType.Hot1:                             
                //Destroy(this.Mandoragora);
                FlagManager.Flag1 = true;
                this.Spring1.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("温泉１に当たった");
                break;
            case SpringType.Hot2:
                //Destroy(this.Mandoragora);
                FlagManager.Flag2 = true;
                this.Spring2.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("温泉2に当たった");
                break;
            case SpringType.Hot3:
                //Destroy(this.Mandoragora);
                FlagManager.Flag3 = true;
                this.Spring3.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("温泉3に当たった");
                break;
            case SpringType.Hot4:
                //Destroy(this.Mandoragora);
                FlagManager.Flag4 = true;
                this.Spring4.GetComponent<BoxCollider2D>().enabled = false;
                Debug.Log("温泉4に当たった");
                break;

        }

    }
}
