using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseDirector : MonoBehaviour {

    public GameObject SelectB;
    public static bool PauseFlg;
    bool RETRY_flg;
    private Vector3 InitVec = new Vector3(0, 50, 0);
    private Vector3 StayVec = new Vector3(0, -200, 0);
    private Vector3 VecMove = new Vector3(0, -1.0f, 0);

	// Use this for initialization
	void Start () {
        PauseFlg = false;
        RETRY_flg = false;
        SelectB.transform.position = InitVec;
	}
	
	// Update is called once per frame
	void Update () {
        if (PauseFlg) {
            GameObject go = SelectB.transform.Find("Stop").gameObject;
            go.SetActive(true);
            Debug.Log("ウェーイ");
            if (SelectB.transform.position.y <= StayVec.y){
                SelectB.transform.position += VecMove;
            }
            else if (RETRY_flg && SelectB.transform.position.y >= InitVec.y) {
                SelectB.transform.position -= InitVec;
                PauseFlg = false;
                RETRY_flg = false;
            }
        }

	}

    public void RETRY() {
        RETRY_flg = true;
        SelectB.transform.position = InitVec;
    }

    public void TITLE_B() {
        PauseFlg = false;
        SceneManager.LoadScene("dummy_TITLE");
    }
}
