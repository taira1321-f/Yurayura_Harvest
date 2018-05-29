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
        if (ToTitleFlg == 1&&A >= 1.0f )
        {
            SceneManager.LoadScene("TitleScene");//シーン移動
            Debug.Log("つうかしたー");
        }
        Debug.Log("比較してるよー");
        if (A <= 0.0f)
        {
            Debug.Log("フラグおります");
            FadeInFlg = false;
        }

    }

    public void SceneChange()
    {
        FadeOutFlg = true;
        ToTitleFlg = 1;
        //SceneManager.LoadScene("DummyScene");
    }
}
