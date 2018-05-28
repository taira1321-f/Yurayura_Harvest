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

	void Start () {
		//温泉をリセット
        //Reset = GameObject.Find("ResetAllHotSpring");
	}
	
	void Update () {
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text= seconds.ToString();
        if (MandGeneretor.Flag1 == true && MandGeneretor.Flag2 == true && MandGeneretor.Flag3 == true && MandGeneretor.Flag4 == true)
        {
            totalTime = 20;
        }
        if(seconds == 0)
        {
            Debug.Log("時間が0になった");
            totalTime = 20;

           Reset.GetComponent<ResetHotSpring>().HotSpringReset();
            
        }

	}
}
