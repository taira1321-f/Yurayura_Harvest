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
<<<<<<< HEAD
            Debug.Log("ロックオン");
=======
>>>>>>> 3f050ed7a6488efa38676b220683cf09fc7f5233
        }
    }
}
