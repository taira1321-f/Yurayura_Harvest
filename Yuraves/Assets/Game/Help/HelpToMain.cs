using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HelpToMain : FadeScript {

    int ToMainFlg = 0;

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
        if ( ToMainFlg == 1&&A >= 1.0f )
        {
            SceneManager.LoadScene("DummyScene");//シーン移動
            Debug.Log("つうかしたー");
        }
        if (A <= 0.0f)
        {
            Debug.Log("フラグおります");
            FadeInFlg = false;
        }

    }

    public void SceneChange()
    {
        FadeOutFlg = true;
        
        ToMainFlg = 1;
        //SceneManager.LoadScene("DummyScene");
    }
}