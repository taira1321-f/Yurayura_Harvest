using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homing_Ebody : MonoBehaviour {
    public GameObject snd;
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.transform.tag == "target"){
            col.GetComponent<MandState>().ctype = MandState.CalotteType.RESET;
            snd.GetComponent<SoundsManager>().Monkey(4);
        }
    }
}
