using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToHelp : FadeScript{
<<<<<<< HEAD
    int ToHelpFlg = 0;
=======
    bool ToHelpFlg;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233

    // Use this for initialization
    void Start(){
        ToHelpFlg = false;
        FadeInFlg = true;
    }

    // Update is called once per frame
    void Update()
    {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);
<<<<<<< HEAD
        if (ToHelpFlg == 1 && A >=1.0f)
        {
            SceneManager.LoadScene("HelpScene");
        }
        if (A <= 0.0f)
        {
=======
        if (ToHelpFlg && ((int)Alfa >= 1)) SceneManager.LoadScene("HelpScene");
        if (Alfa <= 0.0f){
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
            FadeInFlg = false;
            Alfa = 0;
        }

    }

    public void SceneChange(){
        Sound(0);
        FadeOutFlg = true;
<<<<<<< HEAD
        ToHelpFlg = 1;
=======
        ToHelpFlg = true;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    }
}
