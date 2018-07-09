using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_Col_Enemy : MonoBehaviour {
    public bool RockOn;
    // Use this for initialization
    void Start(){
        RockOn = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D col){
        if (col.gameObject.transform.tag == "target") {
            if(!RockOn)RockOn = true;
        }
    }
}
