using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TitleToStart : FadeScript{

<<<<<<< HEAD
    int ToStartFlg = 0;
=======
    bool ToStartFlg;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    
    // Use this for initialization
    void Start () {
        ToStartFlg = false;
        FadeInFlg = true;
    }
	
	// Update is called once per frame
	void Update () {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);

<<<<<<< HEAD
        if (ToStartFlg == 1&&A >=1.0f)
        {
            SceneManager.LoadScene("MainScene");//シーン移動
        }
      
        if (A <= 0.0f)
        {
           
=======
        if (ToStartFlg && ((int)Alfa >= 1)) SceneManager.LoadScene("MainScene");
        if (Alfa <= 0.0f) { 
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
            FadeInFlg = false;
            Alfa = 0;
        }
    }

    public void SceneChange()
    {
        Sound(0);
        FadeOutFlg = true;
<<<<<<< HEAD
        ToStartFlg=1;
=======
        ToStartFlg = true;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
    }

}
