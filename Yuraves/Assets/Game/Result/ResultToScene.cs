using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultToScene : FadeScript {
    int FadeFlg = 0;
	// Use this for initialization
	void Start () {
        FadeInFlg = true;
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
	}
	
	// Update is called once per frame
	void Update () {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);
        if (FadeFlg == 1 && A >= 1.0f) Select();
        else if (A <= 0.0f) FadeInFlg = false;
	}
    void Select() {
        Sound(4);
        FadeOutFlg = true;
        FadeFlg = 1;
    }
}
