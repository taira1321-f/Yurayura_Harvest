using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetHotSpring : MonoBehaviour {
    //温泉
    public GameObject[] Spring;
    private TimerController timercontroller;

     void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (MandGeneretor.Flag1 == true && MandGeneretor.Flag2 == true && MandGeneretor.Flag3 == true && MandGeneretor.Flag4 == true)
        {
            Debug.Log("４つ埋まった");
            Invoke("HotSpringReset", 2);
        }
	}
    public void HotSpringReset()
    {
        //すべてのフラグをfalseへ
        MandGeneretor.Flag1 = false;
        MandGeneretor.Flag2 = false;
        MandGeneretor.Flag3 = false;
        MandGeneretor.Flag4 = false;

        for(int i=0;i>=3;i++){
            //すべての温泉の画像切り替え
            this.Spring[i].GetComponent<ChangeImage>().ChangeStateToStandby();
            //当たり判定の復活
            this.Spring[i].GetComponent<BoxCollider2D>().enabled = true;
        }
    }

}
