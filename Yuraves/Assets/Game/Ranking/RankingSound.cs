using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingSound : MonoBehaviour {
    AudioSource Audio_S;
    public AudioClip[] sounds;
	// Use this for initialization
	void Start () {
        Audio_S = GetComponent<AudioSource>();
        Audio_S.PlayOneShot(sounds[0]);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Select() {
        Audio_S.PlayOneShot(sounds[1]);
    }
}
