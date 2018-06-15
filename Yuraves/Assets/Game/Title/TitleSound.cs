using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSound : MonoBehaviour {
    public AudioSource audio;
    public AudioClip[] bgm;
    public AudioClip[] se;
	// Use this for initialization
	void Start () {
        audio = gameObject.GetComponent<AudioSource>();
        audio.PlayOneShot(bgm[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Select() {
        audio.PlayOneShot(se[0]);
    }
}
