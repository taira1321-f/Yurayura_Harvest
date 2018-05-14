using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {
    public Text timerText;

    public float totalTime;

	int seconds;

	void Start () {
		
	}
	
	void Update () {
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text= seconds.ToString();

	}
}
