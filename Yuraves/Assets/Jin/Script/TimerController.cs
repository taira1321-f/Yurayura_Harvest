using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
    public Text timerText;
    public float totalTime;
	int seconds;

    //リセット
    public GameObject Reset;
    public GameObject MandMane;
    bool[] checkFlg = new bool[4];

	void Start () {
		//温泉をリセット
        //Reset = GameObject.Find("ResetAllHotSpring");
	}
	
	void Update () {
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text= seconds.ToString();
        if (AllTrue())
        {
            totalTime = 20;
        }
        if(seconds == 0)
        {
            totalTime = 20;
           Reset.GetComponent<ResetHotSpring>().HotSpringReset();   
        }
	}
    bool AllTrue()
    {
        int cnt = 0;//trueカウンター
        int i = (checkFlg.Length - 1);//checkFlg配列のサイズを取得
        for (; i >= 0; i--){
            if (checkFlg[i]) cnt++;
        }
        if (cnt == 4) return true;
        else return false;
    }
}
