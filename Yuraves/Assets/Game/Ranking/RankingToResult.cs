using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RankingToResult : FadeScript{
    int ToStartFlg = 0;
    void Start(){
        FadeInFlg = true;
    }
    void Update(){
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);
<<<<<<< HEAD
        if (ToStartFlg == 1 && A >= 1.0f) SceneManager.LoadScene("TitleScene");//シーン移動
        if (A <= 0.0f) FadeInFlg = false;
=======
        if (ToStartFlg == 1 && Alfa >= 1.0f) SceneManager.LoadScene("TitleScene");//シーン移動
        if (Alfa <= 0.0f) FadeInFlg = false;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    }

    public void SceneChange(){
        Sound(3);
        FadeOutFlg = true;
        ToStartFlg = 1;
    }
}
