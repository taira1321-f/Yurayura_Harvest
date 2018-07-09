using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToRanking : FadeScript {
<<<<<<< HEAD
    int ToRankingFlg = 0;
	// Use this for initialization
	void Start () {
=======
    bool ToRankingFlg;
	// Use this for initialization
	void Start () {
        ToRankingFlg = false;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
        FadeInFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);
<<<<<<< HEAD
        if (ToRankingFlg == 1 && A >= 1.0f) SceneManager.LoadScene("Ranking");//後々ランキングシーンに変更
        if (A <= 0.0f) FadeInFlg = false;
=======
        if (ToRankingFlg && ((int)Alfa >= 1)) SceneManager.LoadScene("Ranking");
        if (Alfa <= 0.0f) {
            FadeInFlg = false;
            Alfa = 0;
        } 
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
	}
    public void SceneChange() {
        Sound(0);
        FadeOutFlg = true;
<<<<<<< HEAD
        ToRankingFlg = 1;
=======
        ToRankingFlg = true;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    }
}
