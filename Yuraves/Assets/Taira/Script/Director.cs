using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour {

    enum MODE { PLAY, STAY };
    MODE gameMode;
    public GameObject Canvas;
    public static float CountTime;
    public static int Score;
    public static int MandCont;

	// Use this for initialization
	void Start () {
        Score = 0;
        MandCont = 0;
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        CountTime = 60;
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameMode){
            case MODE.PLAY:
                //CountTime -= Time.deltaTime;
                break;
            case MODE.STAY:
                break;
        }
        if (CountTime <= 0) SceneManager.LoadScene("dummy_TITLE");
	}

    public void MenuButton() {
        if (gameMode == MODE.PLAY){
            gameMode = MODE.STAY;
            PauseDirector.RETRY_flg = true;
            GameObject P_pos = Canvas.transform.Find("Pause").gameObject;
            P_pos.SetActive(false);
        }else if (gameMode == MODE.STAY){
            gameMode = MODE.PLAY;
            PauseDirector.RETRY_flg = false;
            GameObject P_pos = Canvas.transform.Find("Pause").gameObject;
            P_pos.SetActive(true);
        }
    }
}
