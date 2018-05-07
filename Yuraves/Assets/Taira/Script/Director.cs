using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour {

    enum MODE { PLAY, STAY };
    MODE gameMode;
    
    public static float CountTime = 0;
    public static int Score;

	// Use this for initialization
	void Start () {
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
       
	}
	
	// Update is called once per frame
	void Update () {
        if (!PauseDirector.RETRY_flg) CountTime += Time.deltaTime;
        DebugChg();
        switch (gameMode){
            case MODE.PLAY:
                DebugScore();
                break;
            case MODE.STAY:
                Debug.Log("!?");
                break;
        }
      
	}
    void DebugChg() {
        if (Input.GetKeyDown(KeyCode.Z)) gameMode = MODE.PLAY;
        if (Input.GetKeyDown(KeyCode.X)) gameMode = MODE.STAY;
       
    }

    public void MenuButton() {
        Debug.Log("押されたよ");
        if (gameMode == MODE.PLAY)
        {
            gameMode = MODE.STAY;
            PauseDirector.RETRY_flg = true;
        }
        else if (gameMode == MODE.STAY)
        {
            PauseDirector.RETRY_flg = false;
            gameMode = MODE.PLAY;
        }
    }

    void DebugScore() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) Score += 1;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) Score -= 1;
    }
}
