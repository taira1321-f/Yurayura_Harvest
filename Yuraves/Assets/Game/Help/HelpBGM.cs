using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpBGM : MonoBehaviour {
    AudioSource AS;
    public AudioClip BGM;
	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
        AS.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
