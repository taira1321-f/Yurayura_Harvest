using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHotSpring : MonoBehaviour {
    //温泉
    private GameObject Spring1;
    private GameObject Spring2;
    private GameObject Spring3;
    private GameObject Spring4;

    private TimerController timercontroller;

     void Start () {
        //温泉
        Spring1 = GameObject.Find("HotSpring1");
        Spring2 = GameObject.Find("HotSpring2");
        Spring3 = GameObject.Find("HotSpring3");
        Spring4 = GameObject.Find("HotSpring4");

        
	}
	
	// Update is called once per frame
	void Update () {
		if (FlagManager.Flag1 == true && FlagManager.Flag2 == true && FlagManager.Flag3 == true && FlagManager.Flag4 == true)
        {
            Debug.Log("４つ埋まった");
            Invoke("HotSpringReset", 2);
        }
	}
    public void HotSpringReset()
    {
        //すべてのフラグをfalseへ
        FlagManager.Flag1 = false;
        FlagManager.Flag2 = false;
        FlagManager.Flag3 = false;
        FlagManager.Flag4 = false;


        //すべての温泉の画像切り替え
        this.Spring1.GetComponent<ChangeImage>().ChangeStateToStandby();
        this.Spring2.GetComponent<ChangeImage>().ChangeStateToStandby();
        this.Spring3.GetComponent<ChangeImage>().ChangeStateToStandby();
        this.Spring4.GetComponent<ChangeImage>().ChangeStateToStandby();

        //当たり判定の復活
        this.Spring1.GetComponent<BoxCollider2D>().enabled = true;
        this.Spring2.GetComponent<BoxCollider2D>().enabled = true;
        this.Spring3.GetComponent<BoxCollider2D>().enabled = true;
        this.Spring4.GetComponent<BoxCollider2D>().enabled = true;

    }

}
