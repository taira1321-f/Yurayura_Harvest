using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToRanking : FadeScript {
    bool ToRankingFlg;
	// Use this for initialization
	void Start () {
        ToRankingFlg = false;
        FadeInFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);
        if (ToRankingFlg && ((int)Alfa >= 1)) SceneManager.LoadScene("Ranking");
        if (Alfa <= 0.0f) {
            FadeInFlg = false;
            Alfa = 0;
        } 
	}
    public void SceneChange() {
        Sound(0);
        FadeOutFlg = true;
        ToRankingFlg = true;
    }
}
