using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainToScene : FadeScript {
    int FadeFlg = 0;
	// Use this for initialization
	void Start () {
        FadeInFlg = true;
	}
	
	// Update is called once per frame
	void Update () {
        FadeOutSet(FadeOutFlg);
        FadeInSet(FadeInFlg);
<<<<<<< HEAD
        if (FadeFlg == 1 && A >= 1.0f) SelectSound();
        if (A <= 0.0f) FadeInFlg = false;
=======
        if (FadeFlg == 1 && Alfa >= 1.0f) SelectSound();
        if (Alfa <= 0.0f) FadeInFlg = false;
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
	}

    void SelectSound() {
        Sound(1);
        FadeOutFlg = true;
        FadeFlg = 1;
     
    }

    public bool MtoT() {
        return true;
    }
    public bool MtoM() {
        return true;
    }
    
}
