using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Help_Director : FadeScript {
    int H_Fadeflg = 0;
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
        if (H_Fadeflg == 1 && A >= 1.0f) {
            
        }
        if (A <= 0.0f) {
=======
        if (H_Fadeflg == 1 && Alfa >= 1.0f) {
            
        }
        if (Alfa <= 0.0f) {
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
            FadeInFlg = false;
        }
	}
    public void SceneChange() {
        Sound(2);
        FadeOutFlg = true;
        H_Fadeflg = 1;
    }
}
