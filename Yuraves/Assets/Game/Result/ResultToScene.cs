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
<<<<<<< HEAD
        if (FadeFlg == 1 && A >= 1.0f) Select();
        else if (A <= 0.0f) FadeInFlg = false;
=======
        if (FadeFlg == 1 && Alfa >= 1.0f) Select();
        else if (Alfa <= 0.0f) FadeInFlg = false;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
	}
    void Select() {
        Sound(4);
        FadeOutFlg = true;
        FadeFlg = 1;
    }
}
