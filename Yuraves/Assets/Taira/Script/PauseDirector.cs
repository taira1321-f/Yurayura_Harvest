using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDirector : MonoBehaviour {
    
    static public bool RETRY_flg;
    public GameObject Canvas;
    GameObject P_pos;
	// Use this for initialization
	void Start () {
        RETRY_flg = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (RETRY_flg){
            P_pos = Canvas.transform.Find("Pause").gameObject;
            P_pos.SetActive(true);
            P_pos = Canvas.transform.Find("MenuButton").gameObject;
            P_pos.SetActive(false);
        }else{
            P_pos = Canvas.transform.Find("Pause").gameObject;
            P_pos.SetActive(false);
            P_pos = Canvas.transform.Find("MenuButton").gameObject;
            P_pos.SetActive(true);
        }
    }

    public void RETRY() {
        RETRY_flg = false;
        SceneManager.LoadScene("MainScene");
    }

    public void TITLE_B() {
        RETRY_flg = false;
        SceneManager.LoadScene("TitleScene");
    }
    public void REPLAY_B() {
        RETRY_flg = false;
        P_pos = Canvas.transform.Find("Pause").gameObject;
        P_pos.SetActive(false);
        GetComponent<Director>().gameMode = Director.MODE.PLAY;
    }
}
