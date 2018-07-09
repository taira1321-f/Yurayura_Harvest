using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleToHelp : FadeScript{
    int ToHelpFlg = 0;

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
        if (ToHelpFlg == 1 && A >=1.0f)
        {
            SceneManager.LoadScene("HelpScene");
        }
        if (A <= 0.0f)
        {
            FadeInFlg = false;
        }

    }

    public void SceneChange(){
        Sound(0);
        FadeOutFlg = true;
        ToHelpFlg = 1;
    }
}
