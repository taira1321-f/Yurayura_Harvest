using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seach_Player : MonoBehaviour {
    
    public static bool SeachFlg;
    
	// Use this for initialization
	void Start () {
        SeachFlg = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "target"){
            SeachFlg = true;
        }
    }
}
