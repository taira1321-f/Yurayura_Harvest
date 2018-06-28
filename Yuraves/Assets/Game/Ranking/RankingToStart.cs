using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RankingToStart : FadeScript
{

    int ToStartFlg = 0;

    // Use this for initialization
    void Start()
    {
        FadeInFlg = true;
    }

    // Update is called once per frame
    void Update()
    {

        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);

        if (ToStartFlg == 1 && Alfa >= 1.0f)
        {
            SceneManager.LoadScene("MainScene");//シーン移動

        }

        if (Alfa <= 0.0f)
        {

            FadeInFlg = false;
        }


    }

    public void SceneChange()
    {
        Sound(3);
        FadeOutFlg = true;
        ToStartFlg = 1;

        //SceneManager.LoadScene("DummyScene");
    }
    //かわいいよー
}
