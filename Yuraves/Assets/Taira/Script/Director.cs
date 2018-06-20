using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Director : MonoBehaviour {

    public enum MODE { READY, PLAY, STAY, FINISH };
    public MODE gameMode;
    public GameObject Canvas;
    public GameObject sounds;
    public static float CountTime;
    public static int Score;
    public static int MandCont;
    int cnt;
    public GameObject SandF;
    public Sprite[] SandF_sp;
	// Use this for initialization
	void Start () {
        cnt = 0;
        Score = 0;
        MandCont = 0;
        QualitySettings.vSyncCount = 0;     //VSyncをOFFにする
        Application.targetFrameRate = 60;   //ターゲットフレームレート
        CountTime = 60;
        SandF.GetComponent<SpriteRenderer>().sprite = SandF_sp[0];
	}
	
	// Update is called once per frame
	void Update () {
        switch (gameMode){
            case MODE.READY:
                READY_GO();
                break;
            case MODE.PLAY:
                CountTime -= Time.deltaTime;
                if (CountTime <= 0) {
                    CountTime = 60;
                    gameMode = MODE.FINISH;
                }
                break;
            case MODE.STAY:
                break;
            case MODE.FINISH:
                Finish();
                break;
        }
	}
    void READY_GO() {
        Vector2 SFpos = SandF.transform.position;
        if (cnt < 85){
            if ((SFpos.x) <= 0) SFpos.x += 0.1f;
            SandF.transform.position = SFpos;
        }else {
            if ((SFpos.x) <= 5.5f) SFpos.x += 0.2f;
            SandF.transform.position = SFpos;
        }
        if (cnt == 10) sounds.GetComponent<SoundsManager>().StartSE(0);
        else if (cnt == 105) sounds.GetComponent<SoundsManager>().StartSE(1);
        if (cnt++ >= 130){
            cnt = 0;
            gameMode = MODE.PLAY;
            SandF.transform.position = new Vector3(-5.5f, 0, 0);
            SandF.GetComponent<SpriteRenderer>().sprite = SandF_sp[1];
        }
    }
    void Finish() {
        if (cnt++ == 10) sounds.GetComponent<SoundsManager>().FinishSE();
        Vector2 SFpos = SandF.transform.position;
        if (cnt < 75){
            if ((SFpos.x) <= 0) SFpos.x += 0.2f;
            SandF.transform.position = SFpos;
        }
        if (cnt >= 75) {
            cnt = 0;
            gameMode = MODE.READY;
            SceneManager.LoadScene("ResultScene");
        }
    }
    public void MenuButton() {
        sounds.GetComponent<SoundsManager>().Select();
        if (gameMode == MODE.PLAY){
            gameMode = MODE.STAY;
            PauseDirector.RETRY_flg = true;
        }else if (gameMode == MODE.STAY){
            gameMode = MODE.PLAY;
            PauseDirector.RETRY_flg = false;
        }
    }
}
