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

        if (ToStartFlg == 1 && Alfa >= 1.0f)
        {
            SceneManager.LoadScene("TitleScene");//シーン移動
        }

        if (Alfa <= 0.0f)
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
