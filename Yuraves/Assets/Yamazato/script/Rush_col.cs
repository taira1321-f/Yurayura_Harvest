using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush_col : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("OK1");
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("OK2");
            this.GetComponent<rush>().enabled = true;
        }
    }
}