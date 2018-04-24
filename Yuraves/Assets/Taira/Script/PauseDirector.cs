using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseDirector : MonoBehaviour {

    public GameObject[] SelectB;
    bool PauseFlg;

	// Use this for initialization
	void Start () {
        PauseFlg = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (PauseFlg) {
            GameObject go = SelectB[0].transform.Find("Stop").gameObject;
            go.SetActive(true);
            Debug.Log("ウェーイ");
        }

	}

    void flgChg() {
        
    }
}
