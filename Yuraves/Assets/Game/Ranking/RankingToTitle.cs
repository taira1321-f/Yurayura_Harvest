using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RankingToTitle : FadeScript
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

        if (ToStartFlg == 1 && A >= 1.0f)
        {
            SceneManager.LoadScene("TitleScene");//シーン移動

        }

        if (A <= 0.0f)
        {

            FadeInFlg = false;
        }


    }

    public void SceneChange()
    {
        FadeOutFlg = true;
        ToStartFlg = 1;

        //SceneManager.LoadScene("DummyScene");
    }
    //かわいいよー
}
