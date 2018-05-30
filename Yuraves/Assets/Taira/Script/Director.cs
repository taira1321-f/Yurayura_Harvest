using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour {

    enum MODE { PLAY, STAY };
    MODE gameMode;
    
    public static float CountTime;
    public static int Score;

	// Use this for initialization
	void Start () {
        Score = 0;
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        CountTime = 60;
       
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameMode){
            case MODE.PLAY:
                CountTime -= Time.deltaTime;
                break;
            case MODE.STAY:
                
                break;
        }
        if (CountTime <= 0) SceneManager.LoadScene("Dummy_TITLE");
	}

    public void MenuButton() {
        
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
