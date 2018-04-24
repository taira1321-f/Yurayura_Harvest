using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour {

    public GameObject TimeGage;
    Slider slider;
    float CountTime = 0;
    const float LimitTime = 60.0f;
    bool TimeFlg = true;

	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        slider = TimeGage.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (TimeFlg) CountTime += Time.deltaTime;
        if (CountTime >= LimitTime) CountTime = 0;
        slider.value = CountTime / LimitTime;
	}

    public void MenuButton() {
        Debug.Log("押されたよ");
        if (TimeFlg) TimeFlg = false;
        else TimeFlg = true;
    }
}
