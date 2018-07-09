using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HelpToTitle : FadeScript {

    int ToTitleFlg = 0;

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
        if (ToTitleFlg == 1&&Alfa >= 1.0f )
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
        Sound(0);
        FadeOutFlg = true;
        ToTitleFlg = 1;
        //SceneManager.LoadScene("DummyScene");
    }
}
