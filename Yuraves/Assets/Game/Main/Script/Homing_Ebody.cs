using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Ebody : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.transform.tag == "target"){
            Debug.Log("やったぜ");
        }
    }
}
