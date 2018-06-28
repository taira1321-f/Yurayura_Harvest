using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToHelp : FadeScript{
    bool ToHelpFlg;

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
        if (ToHelpFlg && ((int)Alfa >= 1)) SceneManager.LoadScene("HelpScene");
        if (Alfa <= 0.0f){
            FadeInFlg = false;
            Alfa = 0;
        }

    }

    public void SceneChange(){
        Sound(0);
        FadeOutFlg = true;
        ToHelpFlg = true;
    }
}
