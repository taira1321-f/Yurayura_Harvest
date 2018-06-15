using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToRanking : FadeScript {
    int ToRankingFlg = 0;
	// Use this for initialization
	void Start () {
        FadeInFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);
        if (ToRankingFlg == 1 && A >= 1.0f) SceneManager.LoadScene("DummyScene");//後々ランキングシーンに変更
        if (A <= 0.0f) FadeInFlg = false;
	}
    public void SceneChange() {
        Sound(0);
        FadeOutFlg = true;
        ToRankingFlg = 1;
    }
}
