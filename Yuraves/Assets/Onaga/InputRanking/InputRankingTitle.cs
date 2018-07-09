using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InputRankingTitle : FadeScript
{
    int ToStartFlg = 0;
    
    void Start()
    {
        FadeInFlg = true;
    }

    void Update()
    {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);

<<<<<<< HEAD
        if (ToStartFlg == 1 && A >= 1.0f)
=======
        if (ToStartFlg == 1 && Alfa >= 1.0f)
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
        {
            SceneManager.LoadScene("TitleScene");//シーン移動
        }

<<<<<<< HEAD
        if (A <= 0.0f)
=======
        if (Alfa <= 0.0f)
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
        {
            FadeInFlg = false;
        }


    }

    public void SceneChange()
    {
        Sound(5);
        FadeOutFlg = true;
        ToStartFlg = 1;
    }
}
