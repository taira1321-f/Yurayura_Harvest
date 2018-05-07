using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDirector : MonoBehaviour {
    
    static public bool RETRY_flg;
    public GameObject Canvas;
    
	// Use this for initialization
	void Start () {
        RETRY_flg = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (RETRY_flg){
            GameObject P_pos = Canvas.transform.Find("Pause").gameObject;
            P_pos.SetActive(true);
        }else{
            GameObject P_pos = Canvas.transform.Find("Pause").gameObject;
            P_pos.SetActive(false);
        }
    }

    public void RETRY() {
        RETRY_flg = false;
    }

    public void TITLE_B() {
        RETRY_flg = false;
        SceneManager.LoadScene("dummy_TITLE");
    }
}
