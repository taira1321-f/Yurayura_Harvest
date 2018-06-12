using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {

    public GameObject TimeGage;
    Slider slider;
    const float LimitTime = 60.0f;

    public GameObject ScoreText;
    int GetScore;
    
	// Use this for initialization
	void Start () {
        slider = TimeGage.GetComponent<Slider>();
        ScoreText.GetComponent<Text>().text = "Score:0";
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = TimeSlider();
        ScoreText.GetComponent<Text>().text = "" + DebugScore();
	}

    float TimeSlider() {
        float value;

        value = Director.CountTime / LimitTime;

        return value;
    }

    int DebugScore() {
        int score;
        score = Director.Score;
        return score;
    }
}
