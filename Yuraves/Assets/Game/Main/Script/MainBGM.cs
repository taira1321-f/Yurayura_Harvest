using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBGM : MonoBehaviour {
    AudioSource AS;
	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
