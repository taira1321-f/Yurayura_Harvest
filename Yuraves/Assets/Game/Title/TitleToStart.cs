using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleToStart : FadeScript{

    bool ToStartFlg;
    
    // Use this for initialization
    void Start () {
        ToStartFlg = false;
        FadeInFlg = true;
    }
	
	// Update is called once per frame
	void Update () {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);

        if (ToStartFlg && ((int)Alfa >= 1)) SceneManager.LoadScene("MainScene");
        if (Alfa <= 0.0f) { 
            FadeInFlg = false;
            Alfa = 0;
        }
    }

    public void SceneChange()
    {
        Sound(0);
        FadeOutFlg = true;
        ToStartFlg = true;
    }

}
